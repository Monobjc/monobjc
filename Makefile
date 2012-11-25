## =======================================
##  __  __                   _     _
## |  \/  | ___  _ __   ___ | |__ (_) ___ 
## | |\/| |/ _ \| '_ \ / _ \| '_ \| |/ __|
## | |  | | (_) | | | | (_) | |_) | | (__ 
## |_|  |_|\___/|_| |_|\___/|_.__// |\___|
##                              |__/
## Top level makefile
## =======================================

include Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

DIRS= \
	native \
	tools \
	libraries
ifeq ($(TESTING_MODE),true)
	DIRS+= tests
endif

ARCHIVE_PREFIX=Monobjc-$(MONOBJC_VERSION).$(REVISION_NUMBER).0
ARCHIVE_DIR=$(ARCHIVE_PREFIX)
PACKAGE_CONTENT=$(PACKAGE_DIR)/content
PACKAGE_SCRIPT=$(PACKAGE_CONTENT)/post_install.sh
PACKAGE_TEMPLATE=$(PACKAGE_DIR)/Monobjc.pmdoc
PACKAGE_DESCRIPTOR=$(PACKAGE_DIR)/$(ARCHIVE_PREFIX).pmdoc

# ----------------------------------------
# Functions
# ----------------------------------------

make_dir_conditional= \
	if [ $(1) = 1 ]; then \
		$(MKDIR) $(2); \
	fi

# ----------------------------------------
# Targets
# ----------------------------------------

all:
	$(MKDIR) "$(BUILD_DIR)"
	$(MKDIR) "$(DIST_DIR)"
	$(call make_dir_conditional,$(BUILD_FOR_OSX_10_6),$(DIST_DIR)/10.6)
	$(call make_dir_conditional,$(BUILD_FOR_OSX_10_7),$(DIST_DIR)/10.7)
	$(call make_dir_conditional,$(BUILD_FOR_OSX_10_8),$(DIST_DIR)/10.8)
	for i in $(DIRS); do \
		(cd $$i; make all); \
	done;

clean:
	for i in $(DIRS); do \
		(cd $$i; make clean); \
	done;
	$(RMRF) "$(BUILD_DIR)"
	$(RMRF) "$(DIST_DIR)"

generate-doc: all
	for i in $(DIRS); do \
		(cd $$i; make generate-doc); \
	done;

generate-archive: generate-doc
	$(MKDIR) $(ARCHIVE_DIR)
		
	$(CPC) *.rtf $(ARCHIVE_DIR)
	$(CPC) Makefile $(ARCHIVE_DIR)
	$(CPC) Monobjc.mk $(ARCHIVE_DIR)
	$(CPC) Monobjc.sh $(ARCHIVE_DIR)
	$(CPC) Monobjc.sln $(ARCHIVE_DIR)
	$(CPC) Monobjc.snk $(ARCHIVE_DIR)
	$(CPC) README $(ARCHIVE_DIR)
	
	$(CPC) $(DIST_DIR) $(ARCHIVE_DIR)
	$(CPC) $(EXTERNAL_DIR) $(ARCHIVE_DIR)
	$(CPC) --exclude="bin" --exclude="obj" --exclude="*.user*" --exclude="*.pidb" $(LIBRARIES_DIR) $(ARCHIVE_DIR)
	$(CPC) --exclude="build/" --exclude="eglib/" --exclude="xcuserdata/" --exclude="*.xcworkspace" $(NATIVE_DIR) $(ARCHIVE_DIR)
	$(CPC) --exclude="bin" --exclude="obj" --exclude="*.user*" --exclude="*.pidb" $(SAMPLES_DIR) $(ARCHIVE_DIR)
	$(CPC) --exclude="bin" --exclude="obj" --exclude="*.user*" --exclude="*.pidb" $(TOOLS_DIR) $(ARCHIVE_DIR)
	$(CPC) --exclude="bin" --exclude="obj" --exclude="*.user*" --exclude="*.pidb" $(TESTS_DIR) $(ARCHIVE_DIR)

generate-tar: generate-archive
	$(TAR) -zcf $(ARCHIVE_PREFIX).tar.gz $(ARCHIVE_DIR)

generate-package: generate-archive
	$(CPC) $(ARCHIVE_DIR)/ $(PACKAGE_CONTENT)
	
	$(MKDIR) $(PACKAGE_DESCRIPTOR)
	for i in $(PACKAGE_TEMPLATE)/*; do \
		(cat $$i | sed -e 's/version>1.0/version>$(MONOBJC_VERSION).$(REVISION_NUMBER)/g' > $(PACKAGE_DESCRIPTOR)/`basename $$i`); \
	done;

	echo '#!/bin/bash' > $(PACKAGE_SCRIPT)
	echo 'cd "$$2"' >> $(PACKAGE_SCRIPT)
	echo 'chmod a+x ./Monobjc.sh' >> $(PACKAGE_SCRIPT)
	echo 'sudo ./Monobjc.sh install' >> $(PACKAGE_SCRIPT)
	echo 'sudo ./Monobjc.sh install_nant' >> $(PACKAGE_SCRIPT)
	echo 'sudo ./Monobjc.sh install_msbuild' >> $(PACKAGE_SCRIPT)
	echo 'sudo ./Monobjc.sh install_monodoc' >> $(PACKAGE_SCRIPT)

	$(CHMOD) a+rx $(PACKAGE_CONTENT)/*.sh
	#$(PACKAGE_MAKER) --doc $(PACKAGE_DESCRIPTOR) --out $(ARCHIVE_PREFIX).pkg
