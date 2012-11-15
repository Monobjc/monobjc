## =======================================
## Monobjc.AppKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.AppKit
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll"
RESX=$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.resx)
RESOURCES=$(patsubst %.resx,%.resources,$(RESX))
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_E/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_E/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreData_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreData_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreData_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreServices_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_Functions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_T/*.cs) \
	$(filterout $(LIBRARIES_DIR)/Monobjc.Foundation/ApplicationServices_T/CGAffineTransform.cs,$(wildcard $(LIBRARIES_DIR)/Monobjc.Foundation/ApplicationServices_T/*.cs))

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(RESOURCES): $(RESX)
	$(RESGEN) $(RESX) $(RESOURCES)

$(TARGET): $(SOURCES) $(RESOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) -resource:$(RESOURCES) $(SOURCES)
