# ZopfliPng-GUI

GUI tool for lossless compression of Png files.  
It can be handled with simple operations.

## ※Warning

If the size is reduced, the original Png file is overwritten.  
apng is excluded from optimization.

## [usage]

- 1.Download this tool.  
  https://github.com/pea-sys/ZopfliPng-GUI/releases/download/v1.0.0/Release.zip

* 2.Unzip the downloaded file

- 3.Launch ZopfliPng-GUI.exe.

- 4.Drag and drop a directory or Png files onto the form.  
  ![1](https://user-images.githubusercontent.com/49807271/202876614-633c03e9-efd9-4458-b2e7-6b5c63c3898f.png)

- 5.Click the Compress button.  
  ![2](https://user-images.githubusercontent.com/49807271/202876611-09db2210-ecc8-4b44-a145-e68a03d891c5.png)

- 6.Wait until completed.  
  ![3](https://user-images.githubusercontent.com/49807271/202876616-2bbfb2bf-eb42-4dfe-88cd-fdc0fe4554c1.png)

## [Option]

- Ignore files with a compression ratio less than desired.
  An example is a setting to ignore size reductions up to 10%.
  This can be used to deter repository size expansion in Git-managed projects.
  ![o1](https://user-images.githubusercontent.com/49807271/202876612-0206e58f-fd8b-439b-91ba-6cfb5d22648d.png)

## [SupportOS]

---

- Windows10

## [Framework]

---

- .Net 6.0

## [Checker]

---

WInMerge can be used as a tool to ensure that Png files are lossless

## [Reference]

- The native binary file used in this program is the release file here.  
  https://github.com/imagemin/zopflipng-bin

- Original  
  https://github.com/google/zopfli/blob/master/README.zopflipng

## [License]

---

MIT © pea-sys
