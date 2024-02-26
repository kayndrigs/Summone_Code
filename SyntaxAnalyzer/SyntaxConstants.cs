namespace Syntax_Analyzer;

public enum SyntaxConstants {
    SPAWN = 1001,
    BASE = 1002,
    PUSH = 1003,
    HOLD = 1004,
    COMP = 1005,
    RECALL = 1006,
    DESTROY = 1007,
    COMMIT = 1008,
    FOR = 1009,
    TO = 1010,
    IF = 1011,
    ELSE = 1012,
    DO = 1013,
    WHILE = 1014,
    TOWER = 1015,
    VOID = 1016,
    INTER = 1017,
    POOL = 1018,
    PING = 1019,
    BLOAT = 1020,
    BUFF = 1021,
    DEBUFF = 1022,
    PLUS = 1023,
    MINUS = 1024,
    MULTI = 1025,
    DIV = 1026,
    MOD = 1027,
    O_PAREN = 1028,
    C_PAREN = 1029,
    O_BRACE = 1030,
    C_BRACE = 1031,
    O_SQR = 1032,
    C_SQR = 1033,
    OR = 1034,
    AND = 1035,
    NOT = 1036,
    ASSIGN = 1037,
    EQUAL_EQUAL = 1038,
    NOT_EQUAL = 1039,
    SEMICOL = 1040,
    COMMA = 1041,
    PER = 1042,
    GREAT = 1043,
    GREAT_E = 1044,
    LESS = 1045,
    LESS_E = 1046,
    INT_LIT = 1047,
    FLOAT_LIT = 1048,
    STRING_LIT = 1049,
    BOOL_LIT = 1050,
    COMMENT = 1051,
    IDEN = 1052,
    FUNC_NAME = 1053,
    TOWER_NAME = 1054,
    TOWER_ID = 1055,
    WHITESPACE = 1056,
    NEWLINE = 1057,
    TAB = 1058,
    SPACE = 1059,
    PROD_START = 2001,
    PROD_PROGRAM = 2002,
    PROD_GLOBAL_DECLARATION = 2003,
    PROD_GLOBAL_VAR = 2004,
    PROD_GV_INTER = 2005,
    PROD_GV_INTER_TAIL = 2006,
    PROD_G_INTER_ARRAY_DEC = 2007,
    PROD_G_INTER_1D_TAIL = 2008,
    PROD_G_INTER_ELEMENT = 2009,
    PROD_G_ADD_INTER_1D = 2010,
    PROD_G_INTER_2D_TAIL = 2011,
    PROD_G_ADD_INTER_2D = 2012,
    PROD_ADD_GV_INTER_TAIL = 2013,
    PROD_GV_BLOAT = 2014,
    PROD_GV_BLOAT_TAIL = 2015,
    PROD_G_BLOAT_ARRAY_DEC = 2016,
    PROD_G_BLOAT_1D_TAIL = 2017,
    PROD_G_BLOAT_ELEMENT = 2018,
    PROD_G_ADD_BLOAT_1D = 2019,
    PROD_G_BLOAT_2D_TAIL = 2020,
    PROD_G_ADD_BLOAT_2D = 2021,
    PROD_ADD_GV_BLOAT_TAIL = 2022,
    PROD_GV_PING = 2023,
    PROD_G_PING_TAIL = 2024,
    PROD_G_PING_ARRAY_DEC = 2025,
    PROD_G_PING_1D_TAIL = 2026,
    PROD_G_PING_ELEMENT = 2027,
    PROD_G_ADD_PING_1D = 2028,
    PROD_G_PING_2D_TAIL = 2029,
    PROD_G_ADD_PING_2D = 2030,
    PROD_G_PING_ADD = 2031,
    PROD_GV_POOL = 2032,
    PROD_G_POOL_TAIL = 2033,
    PROD_G_POOL_ARRAY_DEC = 2034,
    PROD_G_POOL_1D_TAIL = 2035,
    PROD_G_POOL_ELEMENT = 2036,
    PROD_G_ADD_POOL_1D = 2037,
    PROD_G_POOL_2D_TAIL = 2038,
    PROD_G_ADD_POOL_2D = 2039,
    PROD_G_POOL_ADD = 2040,
    PROD_GLOBAL_COMP = 2041,
    PROD_GC_DATATYPE = 2042,
    PROD_GC_INTER_TAIL = 2043,
    PROD_ADD_GC_INTER_TAIL = 2044,
    PROD_GC_INTER_ARRAY_DEC = 2045,
    PROD_GC_INTER_1D_TAIL = 2046,
    PROD_GC_INTER_2D_TAIL = 2047,
    PROD_GC_BLOAT_TAIL = 2048,
    PROD_ADD_GC_BLOAT_TAIL = 2049,
    PROD_GC_BLOAT_ARRAY_DEC = 2050,
    PROD_GC_BLOAT_1D_TAIL = 2051,
    PROD_GC_BLOAT_2D_TAIL = 2052,
    PROD_GC_PING_TAIL = 2053,
    PROD_ADD_GC_PING_TAIL = 2054,
    PROD_GC_PING_ARRAY_DEC = 2055,
    PROD_GC_PING_1D_TAIL = 2056,
    PROD_GC_PING_2D_TAIL = 2057,
    PROD_GC_POOL_TAIL = 2058,
    PROD_ADD_GC_POOL_TAIL = 2059,
    PROD_GC_POOL_ARRAY_DEC = 2060,
    PROD_GC_POOL_1D_TAIL = 2061,
    PROD_GC_POOL_2D_TAIL = 2062,
    PROD_GLOBAL_TOWER = 2063,
    PROD_TOWER_VAR = 2064,
    PROD_T_MEMBER_TYPE = 2065,
    PROD_T_OP_ARR = 2066,
    PROD_T_ADD_ARR = 2067,
    PROD_ADD_T_MEM = 2068,
    PROD_BASE_PROD = 2069,
    PROD_LOCAL_DEC = 2070,
    PROD_LOCAL_VAR = 2071,
    PROD_LV_INTER = 2072,
    PROD_LV_INT_TAIL = 2073,
    PROD_LV_INTER_VALUE = 2074,
    PROD_MATH_EXPRESSION = 2075,
    PROD_MATH_OPERAND = 2076,
    PROD_MATH_TAIL_EXPRESSION = 2077,
    PROD_MATH_OPERATOR = 2078,
    PROD_INTER_CONVERSION_VALUE = 2079,
    PROD_VALUE_TYPE = 2080,
    PROD_INDEX_VALUE = 2081,
    PROD_2D_VALUE_TYPE = 2082,
    PROD_ARGUMENT = 2083,
    PROD_LITERAL_VALUE = 2084,
    PROD_ADDITIONAL_ARGS = 2085,
    PROD_BUILTIN_FUNC_CALL = 2086,
    PROD_L_INTER_ARRAY_DEC = 2087,
    PROD_L_INTER_1D_TAIL = 2088,
    PROD_L_INTER_ELEMENT = 2089,
    PROD_L_ADD_INTER_1D = 2090,
    PROD_L_INTER_2D_TAIL = 2091,
    PROD_L_ADD_INTER_2D = 2092,
    PROD_ADD_LV_INTER_TAIL = 2093,
    PROD_LV_BLOAT = 2094,
    PROD_LV_BLOAT_TAIL = 2095,
    PROD_LV_BLOAT_VALUE = 2096,
    PROD_BLOAT_CONVERSION_VALUE = 2097,
    PROD_BLOAT_ARRAY_DEC = 2098,
    PROD_L_BLOAT_1D_TAIL = 2099,
    PROD_L_BLOAT_ELEMENT = 2100,
    PROD_L_ADD_BLOAT_1D = 2101,
    PROD_L_BLOAT_2D_TAIL = 2102,
    PROD_L_ADD_BLOAT_2D = 2103,
    PROD_ADD_LV_BLOAT_TAIL = 2104,
    PROD_LV_PING = 2105,
    PROD_LV_PING_TAIL = 2106,
    PROD_LV_PING_VALUE = 2107,
    PROD_PING_CONVERSION_VALUE = 2108,
    PROD_STRING_CONCAT = 2109,
    PROD_STRING_VALUE = 2110,
    PROD_STRING_TAIL_CONCAT = 2111,
    PROD_L_BLOAT_ARRAY_DEC = 2112,
    PROD_L_PING_1D_TAIL = 2113,
    PROD_L_PING_ELEMENT = 2114,
    PROD_L_ADD_PING_1D = 2115,
    PROD_L_PING_2D_TAIL = 2116,
    PROD_L_ADD_PING_2D = 2117,
    PROD_ADD_LV_PING_TAIL = 2118,
    PROD_LV_POOL = 2119,
    PROD_LV_POOL_TAIL = 2120,
    PROD_LV_POOL_VALUE = 2121,
    PROD_POOL_CONVERSION_VALUE = 2122,
    PROD_POOL_CONVERT = 2123,
    PROD_GENERAL_EXPRESSION = 2124,
    PROD_GENERAL_OPERAND = 2125,
    PROD_GENERAL_TAIL_EXPRESSION = 2126,
    PROD_GENERAL_OPERATOR = 2127,
    PROD_L_POOL_ARRAY_DEC = 2128,
    PROD_L_POOL_ELEMENT = 2129,
    PROD_L_POOL_1D_TAIL = 2130,
    PROD_L_ADD_POOL_1D = 2131,
    PROD_L_POOL_2D_TAIL = 2132,
    PROD_L_ADD_POOL_2D = 2133,
    PROD_ADD_GV_POOL_TAIL = 2134,
    PROD_LOCAL_COMP = 2135,
    PROD_LC_DATA_TYPE = 2136,
    PROD_LC_INTER_TAIL = 2137,
    PROD_ADD_LC_INTER_TAIL = 2138,
    PROD_LC_INTER_ARRAY_DEC = 2139,
    PROD_LC_INTER_1D_TAIL = 2140,
    PROD_LC_INTER_2D_TAIL = 2141,
    PROD_LC_BLOAT_TAIL = 2142,
    PROD_ADD_LC_BLOAT_TAIL = 2143,
    PROD_LC_BLOAT_ARRAY_DEC = 2144,
    PROD_LC_BLOAT_1D_TAIL = 2145,
    PROD_LC_BLOAT_2D_TAIL = 2146,
    PROD_LC_PING_TAIL = 2147,
    PROD_ADD_LC_PING_TAIL = 2148,
    PROD_LC_PING_ARRAY_DEC = 2149,
    PROD_LC_PING_1D_TAIL = 2150,
    PROD_LC_PING_2D_TAIL = 2151,
    PROD_LC_POOL_TAIL = 2152,
    PROD_ADD_LC_POOL_TAIL = 2153,
    PROD_LC_POOL_ARRAY_DEC = 2154,
    PROD_LC_POOL_1D_TAIL = 2155,
    PROD_LC_POOL_2D_TAIL = 2156,
    PROD_LOCAL_TOWER = 2157,
    PROD_STATEMENT = 2158,
    PROD_STM_TYPE = 2159,
    PROD_ASSIGN_VALUE_TYPE = 2160,
    PROD_ASSIGNMENT = 2161,
    PROD_ASSIGN_VALUE = 2162,
    PROD_1D_2D_ARRAY = 2163,
    PROD_ASSIGN_ARRAY_ELEMENT = 2164,
    PROD_ADD_ASSIGN_1D = 2165,
    PROD_ADD_ASSIGN_2D = 2166,
    PROD_LOOP_STM = 2167,
    PROD_LOWER_BOUND = 2168,
    PROD_UPPER_BOUND = 2169,
    PROD_CONTENT = 2170,
    PROD_CONDITION = 2171,
    PROD_LOOP_TERMINATOR = 2172,
    PROD_COND_STM = 2173,
    PROD_BODY = 2174,
    PROD_CONTENT_ONELINE = 2175,
    PROD_ELSE_CLAUSE = 2176,
    PROD_PUSH_VALUE = 2177,
    PROD_USER_FUNCTION = 2178,
    PROD_SPAWN_TAIL = 2179,
    PROD_PARAMETER = 2180,
    PROD_ADDITIONAL_PARAM = 2181,
    PROD_DATA_TYPE = 2182,
    PROD_USER_BODY = 2183,
    PROD_INTER_RECALL = 2184,
    PROD_BLOAT_RECALL = 2185,
    PROD_PING_RECALL = 2186,
    PROD_PING_RECALL_VALUE = 2187,
    PROD_POOL_RECALL = 2188
}