#include <stdio.h>
#include <tensorflow/c/c_api.h>
#include "tf_utils.hpp"

#include <iostream>
#include <fstream>
#include <sstream>
#include <string.h>
#include <windows.h>
#include <vector>

extern "C"
{
	__declspec(dllexport) int initializeDll();
	__declspec(dllexport) int finalizeDll();
	__declspec(dllexport) int loadModel(char*, int);
	__declspec(dllexport) int prepareSession(int model_num, int channel);
	__declspec(dllexport) int infer(float*, int, int, float**);
	__declspec(dllexport) void releaseBuffer();
}
#define IMG_SIZE 256
#define MAX_MODEL_NUM 16
float* buffer;

char directory[512];
TF_Graph* graph[MAX_MODEL_NUM];

TF_Status* status;
TF_SessionOptions* options;
TF_Session* sess[MAX_MODEL_NUM];

void getCurrentPath(char* directory)
{
	char buffer[512];
	GetModuleFileNameA(NULL, buffer, 512); // get the DLL path
	char* pos = buffer;
	while (1) {
		char* p = strchr(pos, '\\');
		if (p == NULL) break;
		pos = ++p;
	}
	strncpy(directory, buffer, pos - buffer - 1);
	directory[pos - buffer - 1] = '\0';
}

int initializeDll()
{
	getCurrentPath(directory);
	return 0;
}

int finalizeDll()
{
	for (int i = 0; i < MAX_MODEL_NUM; i++)
	{
		if (graph[i] != nullptr) TF_DeleteGraph(graph[i]);
		if (sess[i] != nullptr)
		{
			TF_CloseSession(sess[i], status);
			if (TF_GetCode(status) != TF_OK)
			{
				TF_DeleteStatus(status);
				return -6;
			}
			TF_DeleteSession(sess[i], status);
			if (TF_GetCode(status) != TF_OK)
			{
				TF_DeleteStatus(status);
				return -7;
			}
		}
	}
	return 0;
}

int loadModel(char* model_name, int model_num)
{
	char model_path[512];
	sprintf(model_path, "%s\\%s", directory, model_name);
	graph[model_num] = tf_utils::LoadGraphDef(model_path);
	if (graph[model_num] == nullptr)
	{
		return -1;
	}

	return 0;
}

int prepareSession(int model_num, int channel)
{
	//	/* prepare input tensor */
	TF_Output input_op = { TF_GraphOperationByName(graph[model_num], "input_1"), 0 };
	if (input_op.oper == nullptr) {
		return -2;
	}

	TF_Tensor* output_tensor = nullptr;

	/* prepare session */
	status = TF_NewStatus();
	options = TF_NewSessionOptions();
	sess[model_num] = TF_NewSession(graph[model_num], options, status);
	TF_DeleteSessionOptions(options);

	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -3;
	}

	const std::vector<std::int64_t> input_dims = { 1, IMG_SIZE, IMG_SIZE, channel };
	std::vector<float> input_vals(IMG_SIZE*IMG_SIZE*channel);	
	TF_Tensor* input_tensor = tf_utils::CreateTensor(TF_FLOAT,
													input_dims.data(), input_dims.size(),
													input_vals.data(), input_vals.size() * sizeof(float));
	
	/* prepare output tensor */
	TF_Output out_op = { TF_GraphOperationByName(graph[model_num], "conv2d_23/Sigmoid"), 0 };
	if (out_op.oper == nullptr) {
		return -4;
	}
	
	/* run session */
	TF_SessionRun(sess[model_num],
		nullptr, // Run options.
		&input_op, &input_tensor, 1, // Input tensors, input tensor values, number of inputs.
		&out_op, &output_tensor, 1, // Output tensors, output tensor values, number of outputs.
		nullptr, 0, // Target operations, number of targets.
		nullptr, // Run metadata.
		status // Output status.
	);

	return 0;
}

int infer(float* images, int model_num, int channel, float** inferred)
{
	/* prepare input tensor */
	TF_Output input_op = { TF_GraphOperationByName(graph[model_num], "input_1"), 0 };
	if (input_op.oper == nullptr) {
		return -2;
	}

	TF_Tensor* output_tensor = nullptr;

	const std::vector<std::int64_t> input_dims = { 1, IMG_SIZE, IMG_SIZE, channel };
	std::vector<float> input_vals(IMG_SIZE*IMG_SIZE*channel);
	for (int i = 0; i < IMG_SIZE*IMG_SIZE*channel; i++)
	{
		input_vals[i] = images[i];
	}

	TF_Tensor* input_tensor = tf_utils::CreateTensor(TF_FLOAT,
													input_dims.data(), input_dims.size(),
													input_vals.data(), input_vals.size() * sizeof(float));

	/* prepare output tensor */
	TF_Output out_op = { TF_GraphOperationByName(graph[model_num], "conv2d_23/Sigmoid"), 0 };
	if (out_op.oper == nullptr) {
		return -4;
	}

	/* run session */
	TF_SessionRun(sess[model_num],
		nullptr, // Run options.
		&input_op, &input_tensor, 1, // Input tensors, input tensor values, number of inputs.
		&out_op, &output_tensor, 1, // Output tensors, output tensor values, number of outputs.
		nullptr, 0, // Target operations, number of targets.
		nullptr, // Run metadata.
		status // Output status.
	);

	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -5;
	}

	buffer = new float[IMG_SIZE*IMG_SIZE*channel];
	const auto result = static_cast<float*>(TF_TensorData(output_tensor));
	memcpy(buffer, result, sizeof(float)*IMG_SIZE*IMG_SIZE*channel);

	TF_DeleteTensor(input_tensor);
	TF_DeleteTensor(output_tensor);

	*inferred = buffer;
	return 0;
}

void releaseBuffer()
{
	if (buffer != nullptr)
	{
		delete[] buffer;
	}
}
