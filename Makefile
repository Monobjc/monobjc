## =======================================
##  __  __				   _	 _
## |  \/  | ___  _ __   ___ | |__ (_) ___ 
## | |\/| |/ _ \| '_ \ / _ \| '_ \| |/ __|
## | |  | | (_) | | | | (_) | |_) | | (__ 
## |_|  |_|\___/|_| |_|\___/|_.__// |\___|
##							  |__/
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

DIRS_ALL=$(DIRS:%=all-%)
DIRS_CLEAN=$(DIRS:%=clean-%)
DIRS_DOC=$(DIRS:%=doc-%)

ARCHIVE_PREFIX=Monobjc-$(MONOBJC_VERSION).$(REVISION_NUMBER).0
ARCHIVE_DIR=$(ARCHIVE_PREFIX)
ARCHIVE_EXCLUDES=--exclude="bin" --exclude="obj" --exclude="*.user*" --exclude="*.pidb" --exclude="*.git*" --exclude="build/" --exclude="eglib/" --exclude="xcuserdata/" --exclude="*.xcworkspace"
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

all: $(BUILD_DIR) $(DIST_DIR) $(DIRS_ALL)

$(BUILD_DIR):
	$(MKDIR) $@

$(DIST_DIR):
	$(MKDIR) $@
	$(MKDIR) $@/10.6
	$(MKDIR) $@/10.7
	$(MKDIR) $@/10.8
	$(MKDIR) $@/10.9

clean: $(DIRS_CLEAN)
	$(RMRF) "$(BUILD_DIR)"
	$(RMRF) "$(DIST_DIR)"
	$(RMRF) "Monobjc-*"

clean-code-gen:
	$(RMRF) "$(TOOLS_DIR)/.generated"
	$(RMRF) "$(TOOLS_DIR)/Monobjc.Generator.NAnt/bin/Release"	
	git clean -fdx

clean-all: clean clean-code-gen

distribute: generate-tar generate-package

generate-doc: all $(DIRS_DOC)

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
	$(CPC) $(ARCHIVE_EXCLUDES) $(NATIVE_DIR) $(ARCHIVE_DIR)
	$(CPC) $(ARCHIVE_EXCLUDES) $(LIBRARIES_DIR) $(ARCHIVE_DIR)
	$(CPC) $(ARCHIVE_EXCLUDES) $(SAMPLES_DIR) $(ARCHIVE_DIR)
	$(CPC) $(ARCHIVE_EXCLUDES) $(TOOLS_DIR) $(ARCHIVE_DIR)
	$(CPC) $(ARCHIVE_EXCLUDES) $(TESTS_DIR) $(ARCHIVE_DIR)

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
	$(PACKAGE_MAKER) --doc $(PACKAGE_DESCRIPTOR) --out $(ARCHIVE_PREFIX).pkg

$(DIRS_ALL):
	$(MAKE) -C $(@:all-%=%) all

$(DIRS_CLEAN):
	$(MAKE) -C $(@:clean-%=%) clean

$(DIRS_DOC):
	$(MAKE) -C $(@:doc-%=%) generate-doc

# ----------------------------------------
# Phony Targets
# ----------------------------------------

.PHONY: subdirs $(DIRS_ALL)
.PHONY: subdirs $(DIRS_CLEAN)
.PHONY: subdirs $(DIRS_DOC)

.PHONY: \
	all \
	clean \
	clean-code-gen \
	clean-all \
	distribute \
	generate-doc \
	generate-archive \
	generate-tar \
	generate-package
