#!/bin/bash

echo "======================================="
echo " __  __                   _     _      "
echo "|  \/  | ___  _ __   ___ | |__ (_) ___ "
echo "| |\/| |/ _ \| '_ \ / _ \| '_ \| |/ __|"
echo "| |  | | (_) | | | | (_) | |_) | | (__ "
echo "|_|  |_|\___/|_| |_|\___/|_.__// |\___|"
echo "                             |__/      "
echo "Installer                              "
echo "======================================="
echo

if [ $UID != 0 ]; then
	echo "!!! You must run this script as a sudoer !!!"
	echo "Please launch this script by typing: sudo $0"
	exit 1
fi

COMMAND=$1

MONO_DIR="/Library/Frameworks/Mono.framework/Versions/Current"
if [ ! -d $MONO_DIR ]; then
	echo "Cannot find Mono.framework. Is it installed ?"
	exit 1
fi

#
# Register all the assemblies and create the pkg-config files
#
function install {

    VERSIONS="10.5 10.6"

    # Perform the installation for each version
    for version in $VERSIONS; do
        echo
        echo "Installing Monobjc $version..."
        echo "=============================="
	
        LIB_DIR="$MONO_DIR/lib/mono/monobjc-$version"

        # Create directory
        mkdir -p "$LIB_DIR"
	
        # Copy native libraries
        cp ./dist/$version/libmonobjc.dylib "$LIB_DIR"
        cp ./dist/$version/runtime "$LIB_DIR"
        chmod a+rx "$LIB_DIR"/libmonobjc.dylib
        chmod a+rx "$LIB_DIR"/runtime

        # Copy the documentation
        for file in `ls dist/$version/Monobjc*.xml`; do
            cp $file "$LIB_DIR"
        done
    
        # Register the Monobjc assemblies in the GAC
        for file in `ls dist/$version/Monobjc*.dll`; do
            gacutil -i "$file" -package monobjc-$version
        done

        # Create the list of assemblies
        LIB_LIST="Libraries="
        LIB_REFERENCES="Libs:"
        for file in `ls dist/$version/Monobjc*.dll`; do
            assembly=`basename $file`
            LIB_LIST="$LIB_LIST \${pkglibdir}/$assembly"
            LIB_REFERENCES="$LIB_REFERENCES -r:\${pkglibdir}/$assembly"
        done
	
        # Create the PKG-CONFIG file
        PC_FILE="$MONO_DIR/share/pkgconfig/monobjc-$version.pc"
        cat > "$PC_FILE" <<EOF
prefix=$MONO_DIR
exec_prefix=\${prefix}
pkglibdir=\${exec_prefix}/lib/mono/monobjc-$version
Libraries=$LIB_LIST

Name: Monobjc
Description: Monobjc Bridge $version
Version: $version

Requires: 
Libs: $LIB_REFERENCES
EOF

    done

    # Make sure that pkg-config has its soft-link
    # because the Mono CSDK doesn't create it
    ln -s "$MONO_DIR/bin/pkg-config" "/usr/bin/pkg-config"

    # Copy the runtime wrappers and soft-link them
    cp "./dist/monobjc" "$MONO_DIR/bin/monobjc"
    cp "./dist/monobjc-nunit" "$MONO_DIR/bin/monobjc-nunit"
    chmod a+rx "$MONO_DIR/bin/monobjc"
    chmod a+rx "$MONO_DIR/bin/monobjc-nunit"
    ln -s "$MONO_DIR/bin/monobjc" "/usr/bin/monobjc"
    ln -s "$MONO_DIR/bin/monobjc-nunit" "/usr/bin/monobjc-nunit"

}

#
# Remove all the registered assemblies
#
function uninstall {

    VERSIONS="10.5 10.6"
    ASSEMBLIES=`gacutil -l | grep Monobjc | awk -F"," '{ print $1 }' | sort -u`

    # Remove assemblies from the GAC
    for assembly in $ASSEMBLIES; do
        gacutil -u $assembly
    done
    
    # Perform the installation for each version
    for version in $VERSIONS; do
        echo
        echo "Uninstalling Monobjc $version..."
        echo "================================"
	
        LIB_DIR="$MONO_DIR/lib/mono/monobjc-$version"
        
        rm -Rf $LIB_DIR
    done

    # Remove executables
    rm -f "/usr/bin/monobjc"
    rm -f "/usr/bin/monobjc-nunit"
    rm -f "$MONO_DIR/bin/monobjc"
    rm -f "$MONO_DIR/bin/monobjc-nunit"
}

# Main entry point
case "$COMMAND" in

    install)
        install
        ;;
    
    uninstall)
        uninstall
        ;;
        
    *)
        echo $"Usage: $0 {install|uninstall}"
        exit 1
        ;;

esac
