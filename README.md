# 7demake
a unity game project that probably wont become anything but it's keeping me occupied.

## requirements
unity 2020.2

## where can i play?
working on it. unity's CI/build integration is fucking miserable.

 - every minor version requires you to generate a new license file using a local docker image, run it through their website, encrypt it, add the encryption key as a github secret, add the encrypted license to your source tree, commit and activate the license with a CI action. NONE of these steps can be automated.
 - the community docker images for unity builds only go up to unity 2020.1. i naively started building my project on the latest version (2020.2) and you can't downgrade your project without hundreds of compiler errors.
 - this probably wouldn't be an issue except the 2020.1 docker image literally segfaults during the license check.
 - downgrading the project to 2019 by creating a new one and copying all the files in looked like it was going to work until the editor crashed because of a usb device check (yes, the vm that exists for about 3 minutes has an issue enumerating usb devices, who would have guessed).
 - i've tried 3 2019 images now, each of them crash with a different error. it was easier to `git reset` the 15 commits to restore the project.
 - building locally takes 7 minutes for an almost empty project, and at the end of the process you get a web page that just shows this:![-.-](https://i.imgur.com/NhJamhG.png)
### Why not try Unity® Cloud Build™, the fast and easy way to build and share your Unity® projects? 
 1. eat shit
 2. it costs 1,800 hamburger coins USD per year
 3. it still doesn't let me automate and test builds with CI

## checklist

 - [x] classic battle scene ui
 - [x] tick system
 - [x] global timer
 - [ ] enemy encounters
 - [ ] party system
 - [ ] modern ui
 - [ ] the rest of the owl

 
## screenshots
day 1, barely functional
![day 1](https://i.imgur.com/eCfmqsU.png)
day 9, somehow even less functional than day 1
![day 9](https://i.imgur.com/1Q8uIku.png)
