## =======================================
## Monobjc.DiscRecordingUI Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.DiscRecordingUI
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.AppKit.dll" -r:"$(DEST_DIR)/Monobjc.DiscRecording.dll"
RESX=
RESOURCES=
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/DiscRecordingUI_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/DiscRecordingUI_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/DiscRecordingUI_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(TARGET): $(SOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) $(SOURCES)
