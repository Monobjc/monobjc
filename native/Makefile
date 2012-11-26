## =======================================
## Runtime makefile
## =======================================

include ../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

DEV_DIR=/Applications/Xcode.app/Contents/Developer
XCODEBUILD=$(DEV_DIR)/usr/bin/xcodebuild
DOXYGEN=/Applications/Doxygen.app/Contents/Resources/doxygen

MAJOR_NUMBER=$(shell echo "$(MONOBJC_VERSION_MAJOR) * 10 + $(MONOBJC_VERSION_MINOR)" | bc)
MINOR_NUMBER=$(shell echo "$(REVISION_NUMBER) / 100" | bc)
BUILD_NUMBER=$(shell echo "$(REVISION_NUMBER) % 100" | bc)
VERSION_NUMBER=$(MAJOR_NUMBER).$(MINOR_NUMBER).$(BUILD_NUMBER)

ARGUMENTS_PROJECT=-project '$(NATIVE_DIR)/Monobjc/Monobjc.xcodeproj' -target runtime
ifeq ($(DEBUG_MODE),true)
	ARGUMENTS_CONFIGURATION=-configuration Debug
else
	ARGUMENTS_CONFIGURATION=-configuration Release
endif
ARGUMENTS_ARCHS=ARCHS='$(NATIVE_ARCHS)' ONLY_ACTIVE_ARCH=false
ARGUMENTS_VERSION=DYLIB_COMPATIBILITY_VERSION='$(MAJOR_NUMBER).0.0' DYLIB_CURRENT_VERSION='$(VERSION_NUMBER)'
ARGUMENTS_DIRS=CONFIGURATION_BUILD_DIR='$(BUILD_DIR)/$(VERSION_NUMBER)' CONFIGURATION_TEMP_DIR='$(BUILD_DIR)/$(VERSION_NUMBER)/tmp'

BINARY_DIR=$(BUILD_DIR)/$(VERSION_NUMBER)/

# ----------------------------------------
# Functions
# ----------------------------------------

copy_files_conditional= \
	if [ $(1) = 1 ]; then \
		$(CPC) --exclude="tmp" --exclude="*.a" --exclude="*.dSYM" "$(2)" "$(3)"; \
	fi

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(DEV_DIR)
	$(XCODEBUILD) $(ARGUMENTS_PROJECT) $(ARGUMENTS_CONFIGURATION) $(ARGUMENTS_ARCHS) $(ARGUMENTS_VERSION) $(ARGUMENTS_DIRS)
	$(call copy_files_conditional,$(BUILD_FOR_OSX_10_6),$(BINARY_DIR),$(DIST_DIR)/10.6)
	$(call copy_files_conditional,$(BUILD_FOR_OSX_10_7),$(BINARY_DIR),$(DIST_DIR)/10.7)
	$(call copy_files_conditional,$(BUILD_FOR_OSX_10_8),$(BINARY_DIR),$(DIST_DIR)/10.8)

clean:

generate-doc:
	if [ ! -f $(DOXYGEN) ]; then echo "Doxygen application was not found. Please check your installation." && exit -1; fi
	(cd $(NATIVE_DIR)/Monobjc; $(DOXYGEN) Doxyfile;)

$(DEV_DIR):
	$(error Xcode application was not found. Please check your installation)

# ----------------------------------------
# Phony Targets
# ----------------------------------------

.PHONY: \
	all \
	clean \
	generate-doc
