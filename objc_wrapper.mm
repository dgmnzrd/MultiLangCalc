#import <Foundation/Foundation.h>
#include "c_code.h"
#include <cmath>

// Declaración del wrapper C++ para multiplicar
extern "C" int cpp_multiply_wrapper(int a, int b);

#pragma mark – Operaciones básicas

extern "C" int sum(int a, int b) {
    return c_sum(a, b);
}

extern "C" int sub(int a, int b) {
    return c_sub(a, b);
}

extern "C" int multiply(int a, int b) {
    return cpp_multiply_wrapper(a, b);
}

extern "C" double divide(double a, double b) {
    return a / b;
}

#pragma mark – Funciones científicas

extern "C" double sc_sin(double a) {
    return sin(a);
}

extern "C" double sc_cos(double a) {
    return cos(a);
}

extern "C" double sc_tan(double a) {
    return tan(a);
}

extern "C" double sc_log(double a) {
    return log(a);
}

extern "C" double sc_pow(double a, double b) {
    return pow(a, b);
}

extern "C" double sc_sqrt(double a) {
    return sqrt(a);
}