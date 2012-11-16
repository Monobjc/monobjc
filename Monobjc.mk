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
export BUILD_DIR?=$(CURDIR)/build
export DIST_DIR?=$(CURDIR)/dist

# Set the files
export KEY_FILE?=$(CURDIR)/Monobjc.snk

# Set the build parameters
export DEBUG_VALUE=false
export TESTING_VALUE=false
export NATIVE_ARCHS=i386

# Set the tools
export CPC=rsync -a
export MCS=dmcs
ifeq ($(TESTING_VALUE),false )
	MCS+= -keyfile:$(KEY_FILE)
endif
export MKDIR=mkdir -p
export RESGEN=resgen
export RMF=rm -Rf
export XBUILD=xbuild /p:Configuration=Release /verbosity:quiet

# Compute the version parts
export MONOBJC_VERSION=5.0
export MONOBJC_VERSION_MAJOR=$(shell echo $(MONOBJC_VERSION) | cut -d "." -f1)
export MONOBJC_VERSION_MINOR=$(shell echo $(MONOBJC_VERSION) | cut -d "." -f2)

export MIN_OSX_VERSION=10.6
export MIN_OSX_VERSION_MAJOR=$(shell echo $(MIN_OSX_VERSION) | cut -d "." -f1)
export MIN_OSX_VERSION_MINOR=$(shell echo $(MIN_OSX_VERSION) | cut -d "." -f2)
export MAX_OSX_VERSION=10.8
export MAX_OSX_VERSION_MAJOR=$(shell echo $(MAX_OSX_VERSION) | cut -d "." -f1)
export MAX_OSX_VERSION_MINOR=$(shell echo $(MAX_OSX_VERSION) | cut -d "." -f2)

export BUILD_FOR_OSX_10_6=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=6 && $(MAX_OSX_VERSION_MINOR) >=6" | bc)
export BUILD_FOR_OSX_10_7=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=7 && $(MAX_OSX_VERSION_MINOR) >=7" | bc)
export BUILD_FOR_OSX_10_8=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=8 && $(MAX_OSX_VERSION_MINOR) >=8" | bc)

# Compute the build number
export DATE_REFERENCE=$(shell date -j -f "%Y-%m-%d" "2007-07-01" "+%s")
export DATE_TODAY=$(shell date "+%s")
export REVISION_NUMBER=$(shell echo "($(DATE_TODAY) - $(DATE_REFERENCE)) / 86400" | bc)
