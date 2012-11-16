## =======================================
## Monobjc.Foundation Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.Foundation
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
XML_DOC=$(DEST_DIR)/$(NAME).xml
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll"
RESX=$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.resx)
RESOURCES=$(patsubst %.resx,%.resources,$(RESX))
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_E/CG*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreFoundation_T/CFType.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_Collections/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_E/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Kernel_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Kernel_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(RESOURCES): $(RESX)
	$(RESGEN) $(RESX) $(RESOURCES)

$(TARGET): $(SOURCES) $(RESOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) -resource:$(RESOURCES) $(SOURCES) -doc:$(XML_DOC)
