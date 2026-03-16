# milestone3cmpt-the-coders
Milestone 3 for team the coders

GPLAG
<<<<<<< HEAD
Ran by: Kayden 

=======
Ran by: Kayden and Theo
>>>>>>> 6ca0bb3 (Updated GPLAG with my attempt)
How the official artifact was discovered:
There is no existing official artifact of GPLAG. Information about paper for GPLAG: 
https://scispace.com/pdf/gplag-detection-of-software-plagiarism-by-program-dependence-4cms55onj4.pdf

I was not able to find any source code through Google searches or by researching the paper's authors.

I found 3 third-party remakes of GPLAG at the follow githubs:

https://github.com/lyc8503/GPlag

https://github.com/vfrunza/GPLAG-Plagerism-Detection

https://github.com/Wancen/GPlag

Environment setup details:
Windows 11 

# Installation and execution steps

# GPLag by Lyc8503:
https://github.com/lyc8503/GPlag
- Download a zip of the code
- Extracted the zip and open in the code in Visual Studio 
- There was no README or dependencies listed anywhere. I tried to determine which dependencies I needed and installed them. I kept having issues installing Joern and could not execute the code. 

# GPLag by vfrunza:
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
- This is the initial error case that occurs when you follow the readme
  <img width="1998" height="262" alt="123" src="https://github.com/user-attachments/assets/f1ff4276-1e5f-4022-86a0-2c889f0f100e" />

In the initial repo VFlib was nonfunctional and it had a bunch of errors:

VFLIB basic compile was incomplete and not compatible, it had lots of hard coded methods calls for 'FullMapping' that were completely nonfunctional and the compiler would yell at us.

Here is an example of one:
![My Image](Pasted%20image%2020260315122159.png)

the root FullMapping class came from the author's compiled VFlib.dll. It uses deprecated no longer in use libraries involving it's sorting and comparator systems.

You can see it here:
![My Image](Pasted%20image%2020260315122422.png|691)
VfState simply isn't correct. It does not have the valid Class constructors and obviously the VfLib given to us just simply doesn't work.

![My Image](Pasted%20image%2020260315122752.png)

This required a big rebuild on the graphIsomorphism.css. I gutted the file with the help of gemini but then we had a whole host of other issues below: 
![[GraphIsomorphism.cs]]

Here is the output after I fixed lots of the issues:
![My Image](Pasted%20image%2020260315120928.png)
As you can see they have hardcoded path files inside their tester You can see here the preprocessor had hardcoded filenames based off of the author:
![My Image](Pasted%20image%2020260315121018.png)

I then had issues with graph VFstate showing again the dependency is having issues:
![[Pasted image 20260315121124.png]]
The author claimed Net.6 is the dependency chain but this isn't the case. This is not compatible with net6 due to its strict sorting criteria. This is viable for the dependency chain of net5 and below but the author was incorrect in declaring this.

This would require us to completely de-compile the vflib.dll and rebuild the comparator from scratch in order to work with the new Visual studio code. I tried downgrading net5 but this proved completely unsuccessful and bricked the entire Vflib and visual studio code session. Thus, this is non functional and we can't continue further as decompilign vflib and rebuilding it for net6 is out of scope for this project.

This doesn't help that the github repo is read only and has been officially archived just over 3 years ago.

# GPLag by Wancen:
https://github.com/Wancen/GPlag
-Downloaded the code
-Tried to install the dependencies from the dependencies file, and it failed because it links to files. I removed all links to the files and tried installing again. I was in luck, as the installation of the dependencies failed, and I couldn't execute the code. 
<img width="1212" height="21" alt="123421345" src="https://github.com/user-attachments/assets/9f1c341a-f9ca-43dd-9e60-4fd0dcc41a96" />


# Benchmark(s) used:
N/A
# Any interventions performed:
- This was talked in detail above ^. This is just a line brief summary:
- Updated GraphIsomormphism to use pre-existing net6. dependency. Attempted gemini and manual.
- Updated Vflib.dll to attempt to fix the compiler error, this wasn't functional but the attempt is in the 'Vflib.dll'
- You can see this work above in the pictures. THe main file changed was GraphIsomorphism.

# Execution outcome and TES classification:
TES-D Non executable, since there was no offical artifact and non-offical artifacts wern't executable 

