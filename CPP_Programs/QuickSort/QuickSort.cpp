#include<iostream>
#include<conio.h>

typedef float TYPE;

void QuickSort(TYPE *T, int Lo, int Hi) {
   int i, j;
   TYPE x;
   x = T[(Lo+Hi)/2];
   i = Lo;
   j = Hi;
   do {
       while (T[i] < x) ++i;
       while (T[j] > x) --j;
       if (i <= j) {
           TYPE tmp = T[i];
           T[i] = T[j];
           T[j] = tmp;
           ++i; --j;
       }
   } while(i < j);
   if (Lo < j) QuickSort(T, Lo, j);
   if (Hi > i) QuickSort(T, i, Hi);
}

int main() {
    std::cout << "Enter the size of the table: ";
    int size;
    std::cin >> size;
    float* Tab = new float[size];
    for (int i = 0; i < size; i++) {
        std::cout << "Enter the value of " << i << " element: ";
        std::cin >> Tab[i];
    }
    QuickSort(Tab, 0, size-1);
    std::cout << std::endl;
    for (int i = 0; i < size; i++)
        std::cout << " " << Tab[i];
    std::cout << std::endl;
    // Uncomment if you need user input before exiting.
    // getch();
    return 0;
}
