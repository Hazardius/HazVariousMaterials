#include<iostream.h>
#include<conio.h>

typedef float TYPE;
 
void QuickSort(TYPE *T, int Lo, int Hi) {
   int i, j;
   TYP x;
   x = T[(Lo+Hi)/2];
   i = Lo;
   j = Hi;
   do {
       while (T[i] < x) ++i;
       while (T[j] > x) --j;
       if (i <= j) {
           TYP tmp = T[i];
           T[i] = T[j];
           T[j] = tmp;
           ++i; --j;
       }
   } while(i < j);
   if (Lo < j) QuickSort(T, Lo, j);
   if (Hi > i) QuickSort(T, i, Hi);
}

int main() {
    cout << "Enter the size of the table: ";
    int size;
    cin >> size;
    float Tab[size];
    for (int i = 0; i < size; i++) {
        cout << "/nEnter the value of " << i << " element: ";
        cin >> Tab[i];
    }
    QuickSort(Tab, 0, size-1);
    cout << endl;
    for (int i = 0; i < size; i++)
        cout << " " << Tab[i];
    getch();
    return 0;
}
