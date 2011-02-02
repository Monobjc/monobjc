// 
// This file is part of Monobjc, a .NET/Objective-C bridge
// Copyright (C) 2007-2011 - Laurent Etiemble
// 
// Monobjc is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// any later version.
// 
// Monobjc is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with Monobjc. If not, see <http://www.gnu.org/licenses/>.
// 
/**
 * @file    ffi-support.mm
 * @brief   Contains diagnosis functions for FFI.
 * @author  Laurent Etiemble <laurent.etiemble@monobjc.net>
 * @date    2009-2010
 */
#include "support-ffi.h"
#include "logging.h"

char *monobjc_get_ffi_type_string(ffi_type *type) {
    if (type == &ffi_type_sint8)    { return strdup("sint8");      }
    if (type == &ffi_type_sint16)   { return strdup("sint16");     }
    if (type == &ffi_type_sint32)   { return strdup("sint32");     }
    if (type == &ffi_type_sint64)   { return strdup("sint64");     }
    if (type == &ffi_type_uint8)    { return strdup("uint8");      }
    if (type == &ffi_type_uint16)   { return strdup("uint16");     }
    if (type == &ffi_type_uint32)   { return strdup("uint32");     }
    if (type == &ffi_type_uint64)   { return strdup("uint64");     }
    
    if (type == &ffi_type_void)     { return strdup("void");       }
    if (type == &ffi_type_pointer)  { return strdup("pointer");    }
    
    if (type == &ffi_type_float)    { return strdup("float");      }
    if (type == &ffi_type_double)   { return strdup("double");     }
    
    if (type->type == FFI_TYPE_STRUCT) {
        GString *buffer = g_string_new("{");
        ffi_type **elements = type->elements;
        int index = 0;
        while (*elements) {
            char *value = monobjc_get_ffi_type_string(*elements);
            g_string_append_printf(buffer, (index ? ", %s" : "%s"), value);
            g_free(value);
            elements++;
            index++;
        }
        g_string_append(buffer, "}");
        return g_string_free(buffer, FALSE);
    }
    
    return strdup("ffi_type_unknown");
}

char *monobjc_get_ffi_cif_string(ffi_cif *cif) {
    GString *buffer = g_string_new("");
    
    char *value = monobjc_get_ffi_type_string(cif->rtype);
    g_string_append_printf(buffer, "%s CIF(", value);
    g_free(value);
    
    unsigned int i = 0;
    while(i < cif->nargs) {
        value = monobjc_get_ffi_type_string(cif->arg_types[i]);
        g_string_append_printf(buffer, (i ? ", %s" : "%s"), value);
        g_free(value);
        i++;
    }
    
    g_string_append(buffer, ")");
    return g_string_free(buffer, FALSE);
}

void monobjc_print_ffi_cif(ffi_cif *cif) {
    char *value = monobjc_get_ffi_cif_string(cif);
    LOG_DEBUG(MONOBJC_DOMAIN_MESSAGING, value);
    g_free(value);
}
