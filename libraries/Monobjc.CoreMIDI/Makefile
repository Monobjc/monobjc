## =======================================
## Monobjc.CoreMIDI Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.CoreMIDI
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll"
RESX=
RESOURCES=
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreMIDI_E/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreMIDI_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreMIDI_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreMIDI_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(TARGET): $(SOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) $(SOURCES)
