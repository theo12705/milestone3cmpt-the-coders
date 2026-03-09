# Milestone 3: CMPT – The Coders

## NIL
**Ran by:** Quinn  

[Paper](https://dl.acm.org/doi/epdf/10.1145/3468264.3468564)

**Repository:** [https://github.com/kusumotolab/NIL](https://github.com/kusumotolab/NIL)

---

## How the official artifact was discovered

The official implementation of NIL was located by searching for the paper title  
**"NIL: Large-Scale Detection of Large-Variance Clones"** along with the keyword *GitHub*.  

This repository ([https://github.com/kusumotolab/NIL](https://github.com/kusumotolab/NIL)) is maintained by Tasuku Nakagawa ([https://github.com/T45K](https://github.com/T45K)), one of the authors of the paper ([official paper](https://dl.acm.org/doi/epdf/10.1145/3468264.3468564)).  

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
From this, it was assumed the issue was due to the Java version. A downgrade was attempted.

**Solution**

Installed JDK 21 via Homebrew:
```brew install openjdk@21```

**Build Successful:**
```
BUILD SUCCESSFUL in 1m 49s
13 actionable tasks: 13 executed
```
## Benchmark(s) used:

[BigCloneEval](https://github.com/jeffsvajlenko/BigCloneEval/blob/master/ReadMe.md#installation-and-setup)

[Paper](https://ieeexplore.ieee.org/abstract/document/6976121)

BigCloneBench Data [here](https://1drv.ms/u/s!AhXbM6MKt_yLj_NwwVacvUzmi6uorA?e=eMu0P4)

IJaDataset Data [here](https://1drv.ms/u/s!AhXbM6MKt_yLj_N15CewgjM7Y8NLKA?e=cScoRJ)

**WorkFlow:**
Detect Clones with NIL tool

```$ ./detectClones -m 2000 -r ../nilRunner.sh -o nil_clones.csv```
.sh
```java -jar ../NIL/build/libs/NIL-all.jar -s "$1" -bce 2>/dev/null```

Import clones for BigCloneEval

```./importClones -t 1 -c nil_clones.csv```

Evaluate clones with BigCloneEval

```./evaluateTool -t 1 -o report.txt --st BOTH --mil 6 --mip 6 --mit 50```


## Any interventions performed:

## Execution outcome and TES classification:


WARNING/TODO:
Don't forget to add logs, error traces and screenshots for any outcomes found. The more the merrier


