## =======================================
## Monobjc.SecurityInterface Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.SecurityInterface
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.AppKit.dll" -r:"$(DEST_DIR)/Monobjc.Security.dll" -r:"$(DEST_DIR)/Monobjc.SecurityFoundation.dll"
RESX=
RESOURCES=
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(filter-out $(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_C/SFAuthorizationPluginView*.cs),$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_C/*.cs)) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(TARGET): $(SOURCES)
	echo $(EXCLUDED_SOURCES)
	echo $(INCLUDED_SOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) $(SOURCES)
