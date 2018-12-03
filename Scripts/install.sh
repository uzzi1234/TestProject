#! /bin/bash

download() {
  echo "Downloading from $url: "
  curl -o $package "$url"
}

install() {
  url=$1
  package=`basename $url`
  install_dir="$(pwd)/Unity3D"
  component_list="component_list.txt"
  download

  echo "Installing $package to $install_dir"
  chmod +x $package
  echo y | ./$package \
    --unattended \
    --components='Unity' \
    --install-location=$install_dir
}

install "https://netstorage.unity3d.com/unity/4550892b6062/MacEditorInstaller/Unity-2018.2.18f1.pkg?_ga=2.26643640.425486085.1543824043-598057053.1543824043"