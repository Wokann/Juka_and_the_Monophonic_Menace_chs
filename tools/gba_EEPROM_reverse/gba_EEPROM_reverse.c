#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define BLOCK_SIZE 8    // 每个块的字节大小

void reverse_bytes(unsigned char *buffer, size_t size) {
    for (size_t i = 0; i < size; i += BLOCK_SIZE) {
        for (size_t j = 0; j < BLOCK_SIZE / 2; ++j) {
            unsigned char temp = buffer[i + j];
            buffer[i + j] = buffer[i + BLOCK_SIZE - 1 - j];
            buffer[i + BLOCK_SIZE - 1 - j] = temp;
        }
    }
}

int main(int argc, char *argv[]) {
    // 检查是否提供了输入文件参数
    if (argc != 2) {
        fprintf(stderr, "Usage: %s <input_file>\n", argv[0]);
        getchar(); // 等待用户按键
        return 1;
    }

    // 获取输入文件名
    const char *inputFileName = argv[1];

    // 查找输入文件名中最后的 '.' 以找到扩展名
    const char *dotPosition = strrchr(inputFileName, '.');

    // 生成输出文件名
    char outputFileName[256];
    if (dotPosition != NULL) {
        // 如果找到扩展名，将后缀 "_reverse" 插入到扩展名前
        size_t baseNameLen = dotPosition - inputFileName;  // 文件名不包括扩展名的长度
        strncpy(outputFileName, inputFileName, baseNameLen); // 复制文件名的基础部分
        outputFileName[baseNameLen] = '\0';  // 确保字符串以 null 结尾
        strcat(outputFileName, "_reverse");  // 添加后缀
        strcat(outputFileName, dotPosition);  // 添加原始扩展名
    } else {
        // 如果没有找到扩展名，直接在文件名后添加后缀
        snprintf(outputFileName, sizeof(outputFileName), "%s_reverse", inputFileName);
    }

    // 打开输入文件
    FILE *inputFile = fopen(inputFileName, "rb");
    if (inputFile == NULL) {
        perror("Error opening input file");
        getchar(); // 等待用户按键
        return 1;
    }

    // 获取文件大小
    fseek(inputFile, 0, SEEK_END);
    long fileSize = ftell(inputFile);
    fseek(inputFile, 0, SEEK_SET);

    // 创建输出文件
    FILE *outputFile = fopen(outputFileName, "wb");
    if (outputFile == NULL) {
        perror("Error creating output file");
        fclose(inputFile);
        getchar(); // 等待用户按键
        return 1;
    }

    // 分配缓冲区
    unsigned char *buffer = (unsigned char *)malloc(fileSize);
    if (buffer == NULL) {
        perror("Memory allocation error");
        fclose(inputFile);
        fclose(outputFile);
        getchar(); // 等待用户按键
        return 1;
    }

    // 读取整个文件到缓冲区
    if (fread(buffer, 1, fileSize, inputFile) != fileSize) {
        perror("Error reading input file");
        free(buffer);
        fclose(inputFile);
        fclose(outputFile);
        getchar(); // 等待用户按键
        return 1;
    }

    // 反转每8字节的字节序
    reverse_bytes(buffer, fileSize);

    // 写入输出文件
    if (fwrite(buffer, 1, fileSize, outputFile) != fileSize) {
        perror("Error writing output file");
        free(buffer);
        fclose(inputFile);
        fclose(outputFile);
        getchar(); // 等待用户按键
        return 1;
    }

    // 释放资源
    free(buffer);
    fclose(inputFile);
    fclose(outputFile);

    printf("File processing completed successfully. Output file: %s\n", outputFileName);
    printf("Press any key to exit...\n");
    getchar(); // 等待用户按键

    return 0;
}
