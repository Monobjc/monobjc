## Common makefile elements
## =======================================

# ----------------------------------------
# Variables
# ----------------------------------------

# Set the directories
export DOC_DIR?=$(CURDIR)/doc
export EXTERNAL_DIR?=$(CURDIR)/external
export LIBRARIES_DIR?=$(CURDIR)/libraries
export NATIVE_DIR?=$(CURDIR)/native
export PACKAGE_DIR?=$(CURDIR)/package
export SAMPLES_DIR?=$(CURDIR)/samples
export TESTS_DIR?=$(CURDIR)/tests
export TOOLS_DIR?=$(CURDIR)/tools
export BUILD_DIR?=$(CURDIR)/build
export DIST_DIR?=$(CURDIR)/dist

# Set the files
export KEY_FILE?=$(CURDIR)/Monobjc.snk

# Set the build parameters
export MONO_SDK?=4
export DEBUG_MODE?=false
export TESTING_MODE?=false
export NATIVE_ARCHS=i386
ifneq (,$(findstring x86_64,$(shell file /usr/bin/mono)))
	NATIVE_ARCHS+= x86_64
endif

# Set the tools
export CHMOD=chmod
export CPC=rsync -a
export LNS=ln -sf
export MCS=dmcs -sdk:$(MONO_SDK) -nowarn:"1574,1584,1591"
ifeq ($(DEBUG_MODE),true)
	MCS+= -debug+ -optimize-
else
	MCS+= -debug- -optimize+
endif
ifeq ($(TESTING_MODE),false)
	MCS+= -keyfile:$(KEY_FILE)
endif
export MDASSEMBLER=mdassembler -f ecma
export MKDIR=mkdir -p
export MONODOCER=monodocer -pretty
export PACKAGE_MAKER=/Developer/Applications/Utilities/PackageMaker.app/Contents/MacOS/PackageMaker --verbose
export RESGEN=resgen
export RMRF=rm -Rf
export SED=sed
export TAR=tar
export XBUILD=xbuild /p:Configuration=Release /verbosity:minimal

# Compute the version parts
export MONOBJC_VERSION=6.0
export MONOBJC_VERSION_MAJOR=$(shell echo $(MONOBJC_VERSION) | cut -d "." -f1)
export MONOBJC_VERSION_MINOR=$(shell echo $(MONOBJC_VERSION) | cut -d "." -f2)

export MIN_OSX_VERSION?=10.7
export MIN_OSX_VERSION_MAJOR=$(shell echo $(MIN_OSX_VERSION) | cut -d "." -f1)
export MIN_OSX_VERSION_MINOR=$(shell echo $(MIN_OSX_VERSION) | cut -d "." -f2)
export MAX_OSX_VERSION?=10.9
export MAX_OSX_VERSION_MAJOR=$(shell echo $(MAX_OSX_VERSION) | cut -d "." -f1)
export MAX_OSX_VERSION_MINOR=$(shell echo $(MAX_OSX_VERSION) | cut -d "." -f2)

export BUILD_FOR_OSX_10_6?=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=6 && $(MAX_OSX_VERSION_MINOR) >=6" | bc)
export BUILD_FOR_OSX_10_7?=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=7 && $(MAX_OSX_VERSION_MINOR) >=7" | bc)
export BUILD_FOR_OSX_10_8?=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=8 && $(MAX_OSX_VERSION_MINOR) >=8" | bc)
export BUILD_FOR_OSX_10_9?=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=9 && $(MAX_OSX_VERSION_MINOR) >=9" | bc)

# Compute the build number
export DATE_REFERENCE=$(shell date -j -f "%Y-%m-%d" "2007-07-01" "+%s")
export DATE_TODAY=$(shell date "+%s")
export REVISION_NUMBER=$(shell echo "($(DATE_TODAY) - $(DATE_REFERENCE)) / 86400" | bc)
