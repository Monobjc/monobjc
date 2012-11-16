## =======================================
## Monobjc.InstantMessage Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.InstantMessage
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.AppKit.dll" -r:"$(DEST_DIR)/Monobjc.AddressBook.dll"
RESX=
RESOURCES=
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/InstantMessage_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/InstantMessage_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/InstantMessage_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(TARGET): $(SOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) $(SOURCES)
