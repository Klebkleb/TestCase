# TestCase
Simple class that compares the output of a program to the correct output given the same input.

# Usage
1. Add 'TestCase.cs' to your project.
2. Add your testcases to your project, don't forget to set them to 'Copy if newer'.
3. Add 'TestCase.Load("filename_of_testcase")' to the start of your program.
4. Replace each Console.ReadLine(), Console.WriteLine() and Console.Write() with TestCase.ReadLine(), TestCase.WriteLine() and TestCase.Write().
5. Run the program!
