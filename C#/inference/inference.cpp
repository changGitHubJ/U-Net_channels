#include <stdio.h>
#include <tensorflow/c/c_api.h>
#include "tf_utils.hpp"

#include <iostream>
#include <fstream>
#include <sstream>
#include <string.h>
#include <windows.h>

extern "C"
{
	__declspec(dllexport) int initializeDll();
	__declspec(dllexport) int finalizeDll();
	__declspec(dllexport) int loadModel_0();
	__declspec(dllexport) int loadModel_1();
	__declspec(dllexport) int loadModel_2();
	__declspec(dllexport) int loadModel_3();
	__declspec(dllexport) int loadModel_4();
	__declspec(dllexport) int loadModel_5();
	__declspec(dllexport) int loadModel_100();
	__declspec(dllexport) int infer_0(float*, float**);
	__declspec(dllexport) int infer_1(float*, float**);
	__declspec(dllexport) int infer_2(float*, float**);
	__declspec(dllexport) int infer_3(float*, float**);
	__declspec(dllexport) int infer_4(float*, float**);
	__declspec(dllexport) int infer_5(float*, float**);
	__declspec(dllexport) int infer_All(float*, float**);
}
#define IMG_SIZE 256
#define DATA_SIZE 1
#define CHANNEL 6
float* buffer;
float* bufferAll;

char directory[512];
TF_Graph *graph0;
TF_Graph *graph1;
TF_Graph *graph2;
TF_Graph *graph3;
TF_Graph *graph4;
TF_Graph *graph5;
TF_Graph *graph100;

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
	buffer = new float[IMG_SIZE*IMG_SIZE];
	bufferAll = new float[IMG_SIZE*IMG_SIZE*CHANNEL];
	return 0;
}

int finalizeDll()
{
	TF_DeleteGraph(graph0);
	delete[] buffer;
	delete[] bufferAll;
	return 0;
}

int loadModel_0()
{
	char model_path[512];
	sprintf(model_path, "%s\\%s", directory, "frozen_graph_0.pb");
	graph0 = tf_utils::LoadGraphDef(model_path);
	if (graph0 == nullptr) {
		return -1;
	}
	return 0;
}

int loadModel_1()
{
	char model_path[512];
	sprintf(model_path, "%s\\%s", directory, "frozen_graph_1.pb");
	graph1 = tf_utils::LoadGraphDef(model_path);
	if (graph1 == nullptr) {
		return -1;
	}
	return 0;
}

int loadModel_2()
{
	char model_path[512];
	sprintf(model_path, "%s\\%s", directory, "frozen_graph_2.pb");
	graph2 = tf_utils::LoadGraphDef(model_path);
	if (graph2 == nullptr) {
		return -1;
	}
	return 0;
}

int loadModel_3()
{
	char model_path[512];
	sprintf(model_path, "%s\\%s", directory, "frozen_graph_3.pb");
	graph3 = tf_utils::LoadGraphDef(model_path);
	if (graph3 == nullptr) {
		return -1;
	}
	return 0;
}

int loadModel_4()
{
	char model_path[512];
	sprintf(model_path, "%s\\%s", directory, "frozen_graph_4.pb");
	graph4 = tf_utils::LoadGraphDef(model_path);
	if (graph4 == nullptr) {
		return -1;
	}
	return 0;
}

int loadModel_5()
{
	char model_path[512];
	sprintf(model_path, "%s\\%s", directory, "frozen_graph_5.pb");
	graph5 = tf_utils::LoadGraphDef(model_path);
	if (graph5 == nullptr) {
		return -1;
	}
	return 0;
}

int loadModel_100()
{
	char model_path[512];
	sprintf(model_path, "%s\\%s", directory, "frozen_graph_100.pb");
	graph100 = tf_utils::LoadGraphDef(model_path);
	if (graph100 == nullptr) {
		return -1;
	}
	return 0;
}

int infer_0(float* images, float** inferred)
{
	/* prepare input tensor */
	TF_Output input_op = { TF_GraphOperationByName(graph0, "input_1"), 0 };
	if (input_op.oper == nullptr) {
		return -2;
	}

	TF_Tensor* output_tensor = nullptr;

	/* prepare session */
	TF_Status* status = TF_NewStatus();
	TF_SessionOptions* options = TF_NewSessionOptions();
	TF_Session* sess = TF_NewSession(graph0, options, status);
	TF_DeleteSessionOptions(options);

	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -3;
	}

	const std::vector<std::int64_t> input_dims = { 1, IMG_SIZE, IMG_SIZE, 1 };
	std::vector<float> input_vals(IMG_SIZE*IMG_SIZE);
	
	for (int i = 0; i < IMG_SIZE*IMG_SIZE; i++)
	{
		input_vals[i] = images[i];
	}

	TF_Tensor* input_tensor = tf_utils::CreateTensor(TF_FLOAT,
													input_dims.data(), input_dims.size(),
													input_vals.data(), input_vals.size() * sizeof(float));

	/* prepare output tensor */
	TF_Output out_op = { TF_GraphOperationByName(graph0, "conv2d_23/Sigmoid"), 0 };
	if (out_op.oper == nullptr) {
		return -4;
	}

	/* run session */
	TF_SessionRun(sess,
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

	const auto result = static_cast<float*>(TF_TensorData(output_tensor));
	for (int i = 0; i < IMG_SIZE; i++)
	{
		for (int j = 0; j < IMG_SIZE; j++)
		{
			buffer[i*IMG_SIZE + j] = result[i*IMG_SIZE + j];
		}
	}

	TF_DeleteTensor(input_tensor);

	TF_CloseSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -6;
	}

	TF_DeleteSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -7;
	}

	TF_DeleteTensor(output_tensor);
	TF_DeleteStatus(status);

	*inferred = buffer;
	return 0;
}

int infer_1(float* images, float** inferred)
{
	/* prepare input tensor */
	TF_Output input_op = { TF_GraphOperationByName(graph1, "input_1"), 0 };
	if (input_op.oper == nullptr) {
		return -2;
	}

	TF_Tensor* output_tensor = nullptr;

	/* prepare session */
	TF_Status* status = TF_NewStatus();
	TF_SessionOptions* options = TF_NewSessionOptions();
	TF_Session* sess = TF_NewSession(graph1, options, status);
	TF_DeleteSessionOptions(options);

	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -3;
	}

	const std::vector<std::int64_t> input_dims = { 1, IMG_SIZE, IMG_SIZE, 1 };
	std::vector<float> input_vals(IMG_SIZE*IMG_SIZE);

	for (int i = 0; i < IMG_SIZE*IMG_SIZE; i++)
	{
		input_vals[i] = images[i];
	}

	TF_Tensor* input_tensor = tf_utils::CreateTensor(TF_FLOAT,
		input_dims.data(), input_dims.size(),
		input_vals.data(), input_vals.size() * sizeof(float));

	/* prepare output tensor */
	TF_Output out_op = { TF_GraphOperationByName(graph1, "conv2d_23/Sigmoid"), 0 };
	if (out_op.oper == nullptr) {
		return -4;
	}

	/* run session */
	TF_SessionRun(sess,
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

	const auto result = static_cast<float*>(TF_TensorData(output_tensor));
	for (int i = 0; i < IMG_SIZE; i++)
	{
		for (int j = 0; j < IMG_SIZE; j++)
		{
			buffer[i*IMG_SIZE + j] = result[i*IMG_SIZE + j];
		}
	}

	TF_DeleteTensor(input_tensor);

	TF_CloseSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -6;
	}

	TF_DeleteSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -7;
	}

	TF_DeleteTensor(output_tensor);
	TF_DeleteStatus(status);

	*inferred = buffer;
	return 0;
}

int infer_2(float* images, float** inferred)
{
	/* prepare input tensor */
	TF_Output input_op = { TF_GraphOperationByName(graph2, "input_1"), 0 };
	if (input_op.oper == nullptr) {
		return -2;
	}

	TF_Tensor* output_tensor = nullptr;

	/* prepare session */
	TF_Status* status = TF_NewStatus();
	TF_SessionOptions* options = TF_NewSessionOptions();
	TF_Session* sess = TF_NewSession(graph2, options, status);
	TF_DeleteSessionOptions(options);

	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -3;
	}

	const std::vector<std::int64_t> input_dims = { 1, IMG_SIZE, IMG_SIZE, 1 };
	std::vector<float> input_vals(IMG_SIZE*IMG_SIZE);

	for (int i = 0; i < IMG_SIZE*IMG_SIZE; i++)
	{
		input_vals[i] = images[i];
	}

	TF_Tensor* input_tensor = tf_utils::CreateTensor(TF_FLOAT,
		input_dims.data(), input_dims.size(),
		input_vals.data(), input_vals.size() * sizeof(float));

	/* prepare output tensor */
	TF_Output out_op = { TF_GraphOperationByName(graph2, "conv2d_23/Sigmoid"), 0 };
	if (out_op.oper == nullptr) {
		return -4;
	}

	/* run session */
	TF_SessionRun(sess,
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

	const auto result = static_cast<float*>(TF_TensorData(output_tensor));
	for (int i = 0; i < IMG_SIZE; i++)
	{
		for (int j = 0; j < IMG_SIZE; j++)
		{
			buffer[i*IMG_SIZE + j] = result[i*IMG_SIZE + j];
		}
	}

	TF_DeleteTensor(input_tensor);

	TF_CloseSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -6;
	}

	TF_DeleteSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -7;
	}

	TF_DeleteTensor(output_tensor);
	TF_DeleteStatus(status);

	*inferred = buffer;
	return 0;
}

int infer_3(float* images, float** inferred)
{
	/* prepare input tensor */
	TF_Output input_op = { TF_GraphOperationByName(graph3, "input_1"), 0 };
	if (input_op.oper == nullptr) {
		return -2;
	}

	TF_Tensor* output_tensor = nullptr;

	/* prepare session */
	TF_Status* status = TF_NewStatus();
	TF_SessionOptions* options = TF_NewSessionOptions();
	TF_Session* sess = TF_NewSession(graph3, options, status);
	TF_DeleteSessionOptions(options);

	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -3;
	}

	const std::vector<std::int64_t> input_dims = { 1, IMG_SIZE, IMG_SIZE, 1 };
	std::vector<float> input_vals(IMG_SIZE*IMG_SIZE);

	for (int i = 0; i < IMG_SIZE*IMG_SIZE; i++)
	{
		input_vals[i] = images[i];
	}

	TF_Tensor* input_tensor = tf_utils::CreateTensor(TF_FLOAT,
		input_dims.data(), input_dims.size(),
		input_vals.data(), input_vals.size() * sizeof(float));

	/* prepare output tensor */
	TF_Output out_op = { TF_GraphOperationByName(graph3, "conv2d_23/Sigmoid"), 0 };
	if (out_op.oper == nullptr) {
		return -4;
	}

	/* run session */
	TF_SessionRun(sess,
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

	const auto result = static_cast<float*>(TF_TensorData(output_tensor));
	for (int i = 0; i < IMG_SIZE; i++)
	{
		for (int j = 0; j < IMG_SIZE; j++)
		{
			buffer[i*IMG_SIZE + j] = result[i*IMG_SIZE + j];
		}
	}

	TF_DeleteTensor(input_tensor);

	TF_CloseSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -6;
	}

	TF_DeleteSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -7;
	}

	TF_DeleteTensor(output_tensor);
	TF_DeleteStatus(status);

	*inferred = buffer;
	return 0;
}

int infer_4(float* images, float** inferred)
{
	/* prepare input tensor */
	TF_Output input_op = { TF_GraphOperationByName(graph4, "input_1"), 0 };
	if (input_op.oper == nullptr) {
		return -2;
	}

	TF_Tensor* output_tensor = nullptr;

	/* prepare session */
	TF_Status* status = TF_NewStatus();
	TF_SessionOptions* options = TF_NewSessionOptions();
	TF_Session* sess = TF_NewSession(graph4, options, status);
	TF_DeleteSessionOptions(options);

	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -3;
	}

	const std::vector<std::int64_t> input_dims = { 1, IMG_SIZE, IMG_SIZE, 1 };
	std::vector<float> input_vals(IMG_SIZE*IMG_SIZE);

	for (int i = 0; i < IMG_SIZE*IMG_SIZE; i++)
	{
		input_vals[i] = images[i];
	}

	TF_Tensor* input_tensor = tf_utils::CreateTensor(TF_FLOAT,
		input_dims.data(), input_dims.size(),
		input_vals.data(), input_vals.size() * sizeof(float));

	/* prepare output tensor */
	TF_Output out_op = { TF_GraphOperationByName(graph4, "conv2d_23/Sigmoid"), 0 };
	if (out_op.oper == nullptr) {
		return -4;
	}

	/* run session */
	TF_SessionRun(sess,
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

	const auto result = static_cast<float*>(TF_TensorData(output_tensor));
	for (int i = 0; i < IMG_SIZE; i++)
	{
		for (int j = 0; j < IMG_SIZE; j++)
		{
			buffer[i*IMG_SIZE + j] = result[i*IMG_SIZE + j];
		}
	}

	TF_DeleteTensor(input_tensor);

	TF_CloseSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -6;
	}

	TF_DeleteSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -7;
	}

	TF_DeleteTensor(output_tensor);
	TF_DeleteStatus(status);

	*inferred = buffer;
	return 0;
}

int infer_5(float* images, float** inferred)
{
	/* prepare input tensor */
	TF_Output input_op = { TF_GraphOperationByName(graph5, "input_1"), 0 };
	if (input_op.oper == nullptr) {
		return -2;
	}

	TF_Tensor* output_tensor = nullptr;

	/* prepare session */
	TF_Status* status = TF_NewStatus();
	TF_SessionOptions* options = TF_NewSessionOptions();
	TF_Session* sess = TF_NewSession(graph5, options, status);
	TF_DeleteSessionOptions(options);

	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -3;
	}

	const std::vector<std::int64_t> input_dims = { 1, IMG_SIZE, IMG_SIZE, 1 };
	std::vector<float> input_vals(IMG_SIZE*IMG_SIZE);

	for (int i = 0; i < IMG_SIZE*IMG_SIZE; i++)
	{
		input_vals[i] = images[i];
	}

	TF_Tensor* input_tensor = tf_utils::CreateTensor(TF_FLOAT,
		input_dims.data(), input_dims.size(),
		input_vals.data(), input_vals.size() * sizeof(float));

	/* prepare output tensor */
	TF_Output out_op = { TF_GraphOperationByName(graph5, "conv2d_23/Sigmoid"), 0 };
	if (out_op.oper == nullptr) {
		return -4;
	}

	/* run session */
	TF_SessionRun(sess,
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

	const auto result = static_cast<float*>(TF_TensorData(output_tensor));
	for (int i = 0; i < IMG_SIZE; i++)
	{
		for (int j = 0; j < IMG_SIZE; j++)
		{
			buffer[i*IMG_SIZE + j] = result[i*IMG_SIZE + j];
		}
	}

	TF_DeleteTensor(input_tensor);

	TF_CloseSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -6;
	}

	TF_DeleteSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -7;
	}

	TF_DeleteTensor(output_tensor);
	TF_DeleteStatus(status);

	*inferred = buffer;
	return 0;
}

int infer_All(float* images, float** inferred)
{
	/* prepare input tensor */
	TF_Output input_op = { TF_GraphOperationByName(graph100, "input_1"), 0 };
	if (input_op.oper == nullptr) {
		return -2;
	}

	TF_Tensor* output_tensor = nullptr;

	/* prepare session */
	TF_Status* status = TF_NewStatus();
	TF_SessionOptions* options = TF_NewSessionOptions();
	TF_Session* sess = TF_NewSession(graph100, options, status);
	TF_DeleteSessionOptions(options);

	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -3;
	}

	const std::vector<std::int64_t> input_dims = { 1, IMG_SIZE, IMG_SIZE, 6 };
	std::vector<float> input_vals(IMG_SIZE*IMG_SIZE*CHANNEL);

	for (int i = 0; i < IMG_SIZE*IMG_SIZE*CHANNEL; i++)
	{
		input_vals[i] = images[i];
	}

	TF_Tensor* input_tensor = tf_utils::CreateTensor(TF_FLOAT,
		input_dims.data(), input_dims.size(),
		input_vals.data(), input_vals.size() * sizeof(float));

	/* prepare output tensor */
	TF_Output out_op = { TF_GraphOperationByName(graph100, "conv2d_23/Sigmoid"), 0 };
	if (out_op.oper == nullptr) {
		return -4;
	}

	/* run session */
	TF_SessionRun(sess,
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

	const auto result = static_cast<float*>(TF_TensorData(output_tensor));
	for (int i = 0; i < IMG_SIZE; i++)
	{
		for (int j = 0; j < IMG_SIZE; j++)
		{
			for (int n = 0; n < IMG_SIZE; n++)
			{
				bufferAll[CHANNEL*(i*IMG_SIZE + j) + n] = result[CHANNEL*(i*IMG_SIZE + j) + n];
			}
		}
	}

	TF_DeleteTensor(input_tensor);

	TF_CloseSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -6;
	}

	TF_DeleteSession(sess, status);
	if (TF_GetCode(status) != TF_OK) {
		TF_DeleteStatus(status);
		return -7;
	}

	TF_DeleteTensor(output_tensor);
	TF_DeleteStatus(status);

	*inferred = bufferAll;
	return 0;
}
