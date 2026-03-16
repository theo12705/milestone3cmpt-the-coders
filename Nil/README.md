# Milestone 3: CMPT – The Coders

## NIL
**Ran by:** Quinn  

---

## How the official artifact was discovered

The official implementation of NIL was located by searching for the paper title along with the keyword *GitHub* **"NIL: Large-Scale Detection of Large-Variance Clones GitHub"**. This search provided the github link as the second link. The first one was a link to research paper.

The repository located was ([https://github.com/kusumotolab/NIL](https://github.com/kusumotolab/NIL)) it is maintained by Tasuku Nakagawa ([https://github.com/T45K](https://github.com/T45K)), one of the authors of the paper ([official paper](https://dl.acm.org/doi/epdf/10.1145/3468264.3468564)).  

The repository contains the source code for the NIL clone detection tool but does not include packaged datasets, or a complete reproducibility environment.

The artifact was accessible as of **March 2026**, and the repository was successfully cloned.

---

## Environment setup details

The tool is implemented in **Java** and built using **Gradle**.  

Ran locally on my device:  

- **OS:** macOS 24.6.0  
- **Architecture:** x86_64  
- **CPU:** Intel i5  
- **RAM:** 8 GB  
- **Java:** OpenJDK 21.0.1

This is the environment I attempted to recreate the results with.

---

## Installation and execution steps

### First Attempt – Failed

```bash
git clone https://github.com/kusumotolab/NIL.git
cd NIL
./gradlew build
```

Output:
```
WARNING: A restricted method in java.lang.System has been called
WARNING: java.lang.System::load has been called by net.rubygrapefruit.platform.internal.NativeLibraryLoader
WARNING: Restricted methods will be blocked in a future release unless native access is enabled

FAILURE: Build failed with an exception.

* What went wrong:
25.0.1

java.lang.IllegalArgumentException: 25.0.1
    at org.jetbrains.kotlin.com.intellij.util.lang.JavaVersion.parse(JavaVersion.java:307)
    at org.jetbrains.kotlin.com.intellij.util.lang.JavaVersion.current(JavaVersion.java:176)
    at org.jetbrains.kotlin.cli.jvm.modules.JavaVersionUtilsKt.isAtLeastJava9(javaVersionUtils.kt:11)
```
From this, it was assumed the issue was due to the Java version. Even though it stated in the [requirements](https://github.com/kusumotolab/NIL/blob/master/REQUIREMENTS.md) that any java version above 11 would work. And in the [readme](https://github.com/kusumotolab/NIL/blob/master/README.md) it state above version 21 would work. A downgrade to version 21 was attempted and turned out to be the solution.

**Solution**

Installed JDK 21 via Homebrew:
```brew install openjdk@21```

**Build Successful:**
```
BUILD SUCCESSFUL in 1m 49s
13 actionable tasks: 13 executed
```
## Benchmark(s) used:

This [BigCloneEval](https://github.com/jeffsvajlenko/BigCloneEval/blob/master/ReadMe.md#installation-and-setup) was located at [EXPERIMENT.md](https://github.com/kusumotolab/NIL/blob/master/EXPERIMENT.md) in the NIL repo. 

The [paper](https://ieeexplore.ieee.org/abstract/document/6976121) was located in the [NIL](https://github.com/kusumotolab/NIL/blob/master/camera-ready.pdf) repo as well.

Both of these data sets were located in [readme](https://github.com/jeffsvajlenko/BigCloneEval) of [BigCloneEval](https://github.com/jeffsvajlenko/BigCloneEval/blob/master/ReadMe.md#installation-and-setup).

BigCloneBench Data [here](https://1drv.ms/u/s!AhXbM6MKt_yLj_NwwVacvUzmi6uorA?e=eMu0P4)

IJaDataset Data [here](https://1drv.ms/u/s!AhXbM6MKt_yLj_N15CewgjM7Y8NLKA?e=cScoRJ)

**WorkFlow:**
Detect Clones with NIL tool

```$ ./detectClones -m 2000 -r ../nilRunner.sh -o nil_clones.csv```
```java -jar ../NIL/build/libs/NIL-all.jar -s "$1" -bce 2>/dev/null```

Import clones for BigCloneEval

```./importClones -t 1 -c nil_clones.csv```

Evaluate clones with BigCloneEval

```./evaluateTool -t 1 -o report.txt --st BOTH --mil 6 --mip 6 --mit 50```


## Any interventions performed:
I continuously attempted to reproduce the output that the paper had for output:
<img width="594" height="222" alt="Screenshot 2026-03-08 at 9 48 45 PM" src="https://github.com/user-attachments/assets/6a11275e-2c1b-473e-a024-1b981f46f433" />

But I was unable to successfully reproduce that output, mine were way smaller. Completely opposite values:
<img width="600" height="220" alt="Screenshot 2026-03-08 at 9 50 06 PM" src="https://github.com/user-attachments/assets/6f640f1a-e797-4d05-b76f-57578650c966" />

I am unsure as to whether I missed a step while following the NIL or BigCloneEval repositorie steps. But after several unsuccessful attempts I am am unable to complete the evaluation.

## Execution outcome and TES classification: 
NIL was fully executable as was BigCloneEval, but I was unable to reproduce the results in the paper in any way. Since I could not get the right results this will be classified as TES-C.



WARNING/TODO:
Don't forget to add logs, error traces and screenshots for any outcomes found. The more the merrier


