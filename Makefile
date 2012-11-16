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

generate-doc:
	for i in $(DIRS); do \
		(cd $$i; make generate-doc); \
	done;

archive:


package:

