## =======================================
## Monobjc.WebKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.WebKit
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll"
RESX=
RESOURCES=
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit.DOM_C/DOM*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit.DOM_P/DOM*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)
	$(filterout $(LIBRARIES_DIR)/Monobjc.Foundation/ApplicationServices_T/WebJavaPlugIn*.cs,$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit_P/*.cs))

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(TARGET): $(SOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) $(SOURCES)
