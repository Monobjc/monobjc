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

COMMAND=$1
VERSION="4.0.0.0"
HASH="d5a8d181860c16be"

# Probe to check if Mono runtime is installed
MONO_DIR="/Library/Frameworks/Mono.framework"
if [ ! -d $MONO_DIR ]; then
	echo "Cannot find Mono.framework. Is it installed ?"
	exit 1
fi

# Probe the Mono runtime to check if it is universal (i386/x86_64)
UNIVERSAL=0
if [[ `file /usr/bin/mono` == *x86_64* ]]; then
	UNIVERSAL=1
fi

#
# Register all the assemblies and create the pkg-config files
#
function install {

    VERSIONS="10.5 10.6 10.7"

    # Perform the installation for each version
    for version in $VERSIONS; do
        echo
        echo "Installing Monobjc $version..."
        echo "=============================="
	
        LIB_DIR="$MONO_DIR/Libraries/mono/monobjc-$version"

        # Create directory
        mkdir -p "$LIB_DIR"
    
        # Copy native elements
        cp "./dist/$version/monobjc.h" "$LIB_DIR"
        
	    if [ $UNIVERSAL == "1" ]; then
	        cp "./dist/$version/libmonobjc.dylib" "$LIB_DIR"
    	    cp "./dist/$version/runtime" "$LIB_DIR"
	    else
            cp "./dist/$version/libmonobjc.dylib" "$LIB_DIR"
            cp "./dist/$version/runtime" "$LIB_DIR"
    		lipo -extract i386 "./dist/$version/libmonobjc.dylib" -output "$LIB_DIR/libmonobjc.dylib"
    		lipo -extract i386 "./dist/$version/runtime" -output "$LIB_DIR/runtime"
	    fi
        
        chmod a+rx "$LIB_DIR/libmonobjc.dylib"
        chmod a+rx "$LIB_DIR/runtime"

        # Copy the documentation
        for file in `ls dist/$version/Monobjc*.xml`; do
            cp $file "$LIB_DIR"
        done
    
        # Register the Monobjc assemblies in the GAC
        for file in `ls dist/$version/Monobjc*.dll`; do
            gacutil -i "$file" -package monobjc-$version
        done

        # Create the list of assemblies
        LIB_LIST=""
        LIB_REFERENCES="Libs:"
        for file in `ls dist/$version/Monobjc*.dll`; do
            assembly=`basename $file`
            LIB_LIST="$LIB_LIST\${pkglibdir}/$assembly "
            LIB_REFERENCES="$LIB_REFERENCES -r:\${pkglibdir}/$assembly"
        done
	
        # Create the PKG-CONFIG file
        PC_FILE="$MONO_DIR/Home/share/pkgconfig/monobjc-$version.pc"
        cat > "$PC_FILE" <<EOF
prefix=$MONO_DIR/Home
exec_prefix=\${prefix}
pkglibdir=\${exec_prefix}/lib/mono/monobjc-$version
Libraries=$LIB_LIST

Name: Monobjc
Description: Monobjc Bridge $version
Version: $version

$LIB_REFERENCES
EOF
    done

    # Make sure that pkg-config has its soft-link
    # because the Mono CSDK doesn't create it
    ln -s "$MONO_DIR/Commands/pkg-config" "/usr/bin/pkg-config"

    # Copy the helper tools
    cp "./dist/Monobjc.Sdp.exe" "$MONO_DIR/Libraries/mono/4.0/Monobjc.Sdp.exe"
    
    # Copy the runtime binary
	cp "./dist/monobjc" "$MONO_DIR/Commands/monobjc"

    # Copy the runtime wrappers and soft-link them
    cp "./dist/monobjc-sdp" "$MONO_DIR/Commands/monobjc-sdp"
    cp "./dist/monobjc-nunit" "$MONO_DIR/Commands/monobjc-nunit"
    chmod a+rx "$MONO_DIR/Commands/monobjc"
    chmod a+rx "$MONO_DIR/Commands/monobjc-sdp"
    chmod a+rx "$MONO_DIR/Commands/monobjc-nunit"
    ln -s "$MONO_DIR/Commands/monobjc" "/usr/bin/monobjc"
    ln -s "$MONO_DIR/Commands/monobjc-sdp" "/usr/bin/monobjc-sdp"
    ln -s "$MONO_DIR/Commands/monobjc-nunit" "/usr/bin/monobjc-nunit"
}

#
# Remove all the registered assemblies
#
function uninstall {

    VERSIONS="10.5 10.6 10.7"
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
	
        LIB_DIR="$MONO_DIR/Libraries/mono/monobjc-$version"
        
        rm -Rf $LIB_DIR
    done

    # Remove executables
    rm -f "/usr/bin/monobjc"
    rm -f "/usr/bin/monobjc-nunit"
    rm -f "$MONO_DIR/Commands/monobjc"
    rm -f "$MONO_DIR/Commands/monobjc-nunit"
    
    # Remove the helper tools
    rm -f "$MONO_DIR/Libraries/mono/4.0/Monobjc.Sdp.exe"
}

function install_nant {
    EXT_DIR="$MONO_DIR/Home/share/NAnt/bin/extensions/common/4.0/"

    # Copy the NAnt tasks
    mkdir -p "$EXT_DIR"
    cp "./dist/Monobjc.NAnt.dll" "$EXT_DIR"
}

function uninstall_nant {
    EXT_DIR="$MONO_DIR/Home/share/NAnt/bin/extensions/common/4.0/"

    # Remove the NAnt tasks
    rm -f "$EXT_DIR/Monobjc.NAnt.dll"
}

function install_msbuild {
    gacutil -i "./dist/Monobjc.MSBuild.dll"

    # Copy the MSBuild tasks and targets
    ln -s "$MONO_DIR/Libraries/mono/gac/Monobjc.MSBuild/$VERSION""__""$HASH/Monobjc.MSBuild.dll" "$MONO_DIR/Libraries/mono/4.0"
    cp ./dist/Monobjc.*.tasks "$MONO_DIR/Libraries/mono/4.0/"
    cp ./dist/Monobjc.*.targets "$MONO_DIR/Libraries/mono/4.0/"
}

function uninstall_msbuild {
    # Remove the MSBuild tasks and targets
    rm -f "$MONO_DIR/Libraries/mono/4.0/Monobjc.Build.dll"
    rm -f "$MONO_DIR/Libraries/mono/4.0/Monobjc.MSBuild.dll"
    rm -f "$MONO_DIR/Libraries/mono/4.0/Monobjc.*.tasks"
    rm -f "$MONO_DIR/Libraries/mono/4.0/Monobjc.*.targets"
}

function install_monodoc {
	MONODOC_DIR="$MONO_DIR/Libraries/monodoc/sources"
	cp ./dist/Monobjc.source "$MONODOC_DIR"
	cp ./dist/Monobjc.tree "$MONODOC_DIR"
	cp ./dist/Monobjc.zip "$MONODOC_DIR"
}

# Main entry point
case "$COMMAND" in

    install)
        uninstall
        install
        ;;
    
    uninstall)
        uninstall
        ;;

    install_nant)
        uninstall_nant
        install_nant
        ;;

    uninstall_nant)
        uninstall_nant
        ;;

    install_msbuild)
        uninstall_msbuild
        install_msbuild
        ;;

    uninstall_msbuild)
        uninstall_msbuild
        ;;

    install_monodoc)
        install_monodoc
        ;;

    *)
        echo $"Usage: $0 {install|uninstall|install_nant|uninstall_nant|install_msbuild|uninstall_msbuild|install_monodoc}"
        exit 1
        ;;

esac
