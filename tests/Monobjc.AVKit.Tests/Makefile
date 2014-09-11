## =======================================
## Monobjc.AVKit.Tests Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.AVKit.Tests
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.AppKit.dll $(DEST_DIR)/Monobjc.CoreMedia.dll $(DEST_DIR)/Monobjc.AVFoundation.dll $(DEST_DIR)/Monobjc.AVKit.dll
SOURCES= \
	$(wildcard $(TESTS_DIR)/Monobjc.Foundation.Tests/Common/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
