# milestone3cmpt-the-coders
Milestone 3 for team the coders

GPLAG
Ran by: Kayden 
How the official artifact was discovered:
There is no existing official artifact of GPLAG. Information about paper for GPLAG: 
https://scispace.com/pdf/gplag-detection-of-software-plagiarism-by-program-dependence-4cms55onj4.pdf

I was not able to find any source code through Google searches or by researching the paper's authors.

I found 3 third-party remakes of GPLAG at the follow githubs:
https://github.com/lyc8503/GPlag,
https://github.com/vfrunza/GPLAG-Plagerism-Detection,
https://github.com/Wancen/GPlag,

Environment setup details:
Windows 11 


Installation and execution steps:
https://github.com/lyc8503/GPlag
- Download a zip of the code
- Extracted the zip and open in the code in Visual Studio 
- There was no README or dependencies listed anywhere. I tried to determine which dependencies I needed and installed them. I kept having issues installing Joern and could not execute the code. 

https://github.com/vfrunza/GPLAG-Plagerism-Detection
- Downloaded the code 
- Extracted the zip and started following the README
  1. Download this repo.
  2. Open the GPLAG-PD.sln solution file. It will open new instance of Visual Studio.
  3. Right clik on the project in the solutioon explorer, click Add then Project Reference.
  4. Click Browse in the left hand sidebar. Then click Browse in the bottom right.
  5. Locate the file VfLib.dll in the root of the repo and add it as a reference.
  6. In Program.cs I've left a sample of test cases you can run. Simply comment out/in the files you wish to run.
  7. Press F5 to run the project.
- When I ran the project, there was a problem building because of syntax errors; there were no simple fixes to the errors, and fixing the errors would have changed the code a lot. Code was not executed.
  <img width="1998" height="262" alt="123" src="https://github.com/user-attachments/assets/f1ff4276-1e5f-4022-86a0-2c889f0f100e" />

https://github.com/Wancen/GPlag
-Downloaded the code
-Tried to install the dependencies from the dependencies file, and it failed because it links to files. I removed all links to the files and tried installing again. I was in luck, as the installation of the dependencies failed, and I couldn't execute the code. 
<img width="1212" height="21" alt="123421345" src="https://github.com/user-attachments/assets/9f1c341a-f9ca-43dd-9e60-4fd0dcc41a96" />



Benchmark(s) used:
N/A
Any interventions performed:

Execution outcome and TES classification:
ES-D Non executable since there was no offical artifact and non-offical artifacts wern't executable 

WARNING/TODO:
Don't forget to add logs, error traces, and screenshots for any outcomes found. The more the merrier
