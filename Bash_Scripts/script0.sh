#!/bin/bash
#Script prints directory names of the subdirectories of the current directory.
find . -mindepth 2 -maxdepth 2 -type d -print
