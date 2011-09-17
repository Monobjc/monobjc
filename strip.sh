#!/bin/bash

FOLDER=stripped

rm -Rf $FOLDER.libraries

# Get all the files from the src folder
find libraries -type f > .allfiles

# Filter source files
egrep ".cs$" .allfiles > .sourcefiles

# Filter other files
egrep -v ".cs$" .allfiles > .otherfiles

for file in `cat .otherfiles`
do
	echo "Processing $file..."
    mkdir -p "$FOLDER/$file"
    rm -Rf "$FOLDER/$file"
	cp "$file" "$FOLDER/$file"
done

for file in `cat .sourcefiles`
do
	echo "Stripping $file..."
    mkdir -p "$FOLDER/$file"
    rm -Rf "$FOLDER/$file"
	sed '/\/\/\//d' "$file" > "$FOLDER/$file"
done

rm -f .allfiles
rm -f .sourcefiles
rm -f .otherfiles
