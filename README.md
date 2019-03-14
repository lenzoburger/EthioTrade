# EthioCoffeeWholesalers-WebApp
Web Application for supporting wholesale coffee business processes. Built using the latest in ASP .Net Core WebApi(v2.2), Angular (v7),  Entity Framework, Bootstrap, Font-Awesome, sql-lite &amp; Azure.

### Restore/Run
1. Clone repo. In _terminal/cmd_ window run `git clone https://github.com/lenzoburger/EthioCoffeeWholesalers-WebApp.git`
2. Change current directory to repo folder `cd EthioCoffeeWholesalers-WebApp`
3. Open two _terminal/cmd_ windows
4. **Terminal 1 (WebAPI)**
   * Change to _EthCoffee.api_ directory `cd EthCoffee.api`
   * Restore project dependencies and tools `dotnet restore`
   * Build Project `dotnet build`
   * Run WebAPI `dotnet run` or `dotnet watch run`
5. **Terminal 2 (Angular App)**
   *  Change to _EthCoffee-SPA_ directory `cd EthCoffee-SPA`
   *  Restore app dependencies/_node-modules_ `npm install`
   *  Run app `ng serve`
   *  Launch browser and navigate to `http://localhost:4200/`

### Development Tools/Dependecies
1. Dotnet-sdk (v2.2+)  &nbsp;&nbsp;&nbsp;&nbsp;-> https://dotnet.microsoft.com/download
2. Node (v10+)           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-> https://nodejs.org/en/download/
3. AngularCLi (v7+)     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-> https://cli.angular.io/ `npm install -g @angular/cli`
4. Notepad++            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-> https://notepad-plus-plus.org/download
5. Git                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-> https://git-scm.com/downloads
6. Postman              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-> https://www.getpostman.com/downloads/
7. SQLLite.DB.Browser   &nbsp;&nbsp;&nbsp;&nbsp;-> https://sqlitebrowser.org/dl/
8. VSCode + _Extensions_ &nbsp;-> https://code.visualstudio.com/download    (_insiders https://code.visualstudio.com/insiders/ )_
   * _Angular Files (Alexander Ivanichev)_
   * _Angular Language Service (Angular)_
   * _Angular v7 Snippets (John Papa)_
   * _angular2-switcher (infinity1207)_
   * _Auto Rename Tag (Jun Han)_
   * _Bracket Pair Colorizer 2 (Coenraads)_
   * _C# (Microsoft)_
   * _C# Extensions (jchannon)_
   * _Debugger for chrome (Microsoft)_
   * _Markdown All in One_ (Yu Zhang)
   * _Markdown Preview Enhanced (Yiyi Wang)_
   * _Meterial Icon Theme (Philipp Kief)_
   * _Nuget Package Manger (jmrog)_
   * _Path Intellisense (Christian Kohler)_
   * _Prettier - Code Formatter (Esben Peterson)_
   * _TSLint (Microsoft)_
   * _TSLint (Microsoft)_