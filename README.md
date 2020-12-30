# Grabli

===

Grabli is a bunch of solutions and ideas for Unity3d. All the code are under MIT license. The main purpose of this project is to share solutions for everyday tasks and gather feedback. And of course, all the ideas about how to make this code better, more stable and more flexible are welcome.

# Main blocks
## Pools
## Extensions
## Utils
## WrappedUnity

# Installation
This repository follows [Unity3d package layout convention](https://docs.unity3d.com/Manual/cus-layout.html). It means, you can import it into your project as a package.
Also, you can attach it to your project as a git submodule.
## Install through the package manager
1. Prepare the repository URL. You need to select one according to your purpose.

*  For fetching the latest release
```
https://github.com/fedorenkosergiy/Grabli.git
```

* For fetching the specific version. Where x.y.z is a version. For example, 0.0.1.
```
https://github.com/fedorenkosergiy/Grabli.git#x.y.z
```

* For fetching the latest commit of the development branch
```
https://github.com/fedorenkosergiy/Grabli.git#develop
```
2. Open the package manager. Use menu item *Window->Package Manager*
3. Click on *+* button. And select a context menu item *Add package from git URL...*

![AddPackageFromGitUrl]

4. Paste the repository URL into the appeared text field. And press *Add*

![AddPackageFromGitUrlPressButtonAdd]

In case you want to know better all the details of installing a package from git URL you can visit a [Unity3d manual page](https://docs.unity3d.com/Manual/upm-ui-giturl.html)

## Install as a git submodule

## Install dependencies
### Moq
Grabli uses [Moq](https://github.com/moq) framework to perform unit tests. You have to install it to be able running all the tests in your project.
Here is an awesome tutorial that will help you to install Moq framework.

<a href="https://youtu.be/enwxxffhvHQ?t=311" target="_blank"><img src="http://img.youtube.com/vi/enwxxffhvHQ/0.jpg" 
alt="Unit Testing - Part I | Mocks and Stubs | Install Moq | Unity Tutorial" width="240" height="180" border="10" /></a>
# Releases
There are no releases yet






[AddPackageFromGitUrl]: https://github.com/fedorenkosergiy/Grabli/raw/develop/Documentation~/Illustrations/AddPackageFromGitUrl.jpg
[AddPackageFromGitUrlPressButtonAdd]: https://github.com/fedorenkosergiy/Grabli/raw/develop/Documentation~/Illustrations/AddPackageFromGitUrlPressButtonAdd.jpg
