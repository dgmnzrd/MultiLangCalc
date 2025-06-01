#include <iostream>

int cpp_multiply(int a, int b) {
    return a * b;
}

// Envoltorio con linkage C para exponerlo a Objective-C++
extern "C" int cpp_multiply_wrapper(int a, int b) {
    return cpp_multiply(a, b);
}