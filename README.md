# WOWApiScanner-Net10
World Of Warcraft API Auction Scanner - completely re-written in .Net 10 /  C# 14 - cross-platform compatitble. Scans the World of Warcraft Auction House for a configurable number of realms using their REST Api, then allowed searching using a wide variety of criteria to find bargains.

![API Scanner In Dark Mode](screenshots/DarkMode-01.png)

![API Scanner In Light Mode](screenshots/LightMode-01.png)

Brief overview of improvements in this new version:
- Completely re-written in .Net 10 / C# 14
- Cross-platform support between Windows, Mac and Linux
- Native support for Dark and Light Themes, easily changeable from drop-down menu
- Much more efficient coding making use of new LINQ queries on lists
- Code decluttered, simplified and more modularized
- Multi-threaded action data fetching implement with async/await with Func<T, Task>
- All stored data files now in .json format rather than a mix of .json and .xml
- Much better to create, copy and edit search profiles
- Using built-in .Net System.Text.Json for json parsing instead of Newtonsoft
