## Common makefile elements
## =======================================

# ----------------------------------------
# Variables
# ----------------------------------------

# Set the directories
export DOC_DIR ?= $(CURDIR)/doc
export EXTERNAL_DIR ?= $(CURDIR)/external
export LIBRARIES_DIR ?= $(CURDIR)/libraries
export NATIVE_DIR ?= $(CURDIR)/native
export BUILD_DIR ?= $(CURDIR)/build
export DIST_DIR ?= $(CURDIR)/dist

# Set the files
export KEY_FILE ?= $(CURDIR)/Monobjc.snk

# Set the build parameters
DEBUG_VALUE=false
TESTING_VALUE=false
NATIVE_ARCHS=i386

# Set the tools
MCS = dmcs
RESGEN = resgen
ifeq ($(TESTING_VALUE),false )
	MCS+= -keyfile:$(KEY_FILE)
endif

# Compute the version parts
MONOBJC_VERSION=5.0
MONOBJC_VERSION_MAJOR=$(shell echo $(MONOBJC_VERSION) | cut -d "." -f1)
MONOBJC_VERSION_MINOR=$(shell echo $(MONOBJC_VERSION) | cut -d "." -f2)

MIN_OSX_VERSION=10.6
MIN_OSX_VERSION_MAJOR=$(shell echo $(MIN_OSX_VERSION) | cut -d "." -f1)
MIN_OSX_VERSION_MINOR=$(shell echo $(MIN_OSX_VERSION) | cut -d "." -f2)
MAX_OSX_VERSION=10.8
MAX_OSX_VERSION_MAJOR=$(shell echo $(MAX_OSX_VERSION) | cut -d "." -f1)
MAX_OSX_VERSION_MINOR=$(shell echo $(MAX_OSX_VERSION) | cut -d "." -f2)

BUILD_FOR_OSX_10_6=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=6 && $(MAX_OSX_VERSION_MINOR) >=6" | bc)
BUILD_FOR_OSX_10_7=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=7 && $(MAX_OSX_VERSION_MINOR) >=7" | bc)
BUILD_FOR_OSX_10_8=$(shell echo "$(MIN_OSX_VERSION_MINOR) <=8 && $(MAX_OSX_VERSION_MINOR) >=8" | bc)

# Compute the build number
DATE_REFERENCE=$(shell date -j -f "%Y-%m-%d" "2007-07-01" "+%s")
DATE_TODAY=$(shell date "+%s")
REVISION_NUMBER=$(shell echo "($(DATE_TODAY) - $(DATE_REFERENCE)) / 86400" | bc)

# ----------------------------------------
# Functions
# ----------------------------------------

make_dir_conditional= \
	if [ $(1) = 1 ]; then \
		mkdir -p $(2); \
	fi

copy_files_conditional= \
	if [ $(1) = 1 ]; then \
		rsync -a --exclude="tmp" "$(2)" "$(3)"; \
	fi
