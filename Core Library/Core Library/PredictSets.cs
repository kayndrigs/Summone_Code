namespace Core.Library;

public class PredictSets
{
    string start = "inter pool bloat ping comp tower spawn";
    string program = "inter bloat ping pool comp tower";
    string global_dec = "inter pool bloat ping comp tower spawn";
    string global_var = "inter pool bloat ping";
    string gv_inter = "Identifier";
    string gv_inter_tail = "= [ , ;";
    string g_inter_array_dec = "[";
    string g_inter_1d_tail = "= [ , ;";
    string g_inter_element = "InterLiteral";
    string g_add_inter_1d = ", }";
    string g_inter_2d_tail =  "= , ;";
    string g_add_inter_2d = ", }";
    string add_gv_inter_tail = ", ;";
    string gv_bloat = "Identifier";
    string gv_bloat_tail = "= [ , ;";
    string g_bloat_array_dec = "[";
    string g_bloat_1d_tail = "= [ , ;";
    string g_bloat_element = "BloatLiteral";
    string g_add_bloat_1d = ", }";
    string g_bloat_2d_tail = "= , ;";
    string g_add_bloat_2d = ", }";
    string add_gv_bloat_tail = ", ;";
    string gv_ping = "Identifier";
    string g_ping_tail = "= [ , ;";
    string g_ping_array_dec = "[";
    string g_ping_1d_tail = "= [ , ;";
    string g_ping_element = "PingLiteral";
    string g_add_ping_1d = ", }";
    string g_ping_2d_tail = "= , ;";
    string g_add_ping_2d = ", }";
    string g_ping_add = ", ;";
    string gv_pool = "Identifier";
    string g_pool_tail = "= [ , ;";
    string g_pool_array_dec = "[";
    string g_pool_1d_tail = "= [ , ;";
    string g_pool_element = "PoolLiteral";
    string g_add_pool_1d = ", }";
    string g_pool_2d_tail = "= , ;";
    string g_add_pool_2d = ", }";
    string g_pool_add = ", ;";
    string global_comp = "comp";
    string gc_datatype = "inter bloat ping pool";
    string gc_inter_tail = "= [";
    string add_gc_inter_tail = ", ;";
    string gc_inter_array_dec = "[";
    string gc_inter_1d_tail = "= [";
    string gc_inter_2d_tail = "=";
    string gc_bloat_tail = "= [";
    string add_gc_bloat_tail = ", ;";
    string gc_bloat_array_dec = "[";
    string gc_bloat_1d_tail = "= [";
    string gc_bloat_2d_tail = "=";
    string gc_ping_tail = "= [";
    string add_gc_ping_tail = ", ;";
    string gc_ping_array_dec = "[";
    string gc_ping_1d_tail = "= [";
    string gc_ping_2d_tail = "=";
    string gc_pool_tail = "= [";
    string add_gc_pool_tail = ", ;";
    string gc_pool_array_dec = "[";
    string gc_pool_1d_tail = "= [";
    string gc_pool_2d_tail = "=";
    string global_tower = "tower";
    string tower_var = "inter bloat ping pool";
    string t_member_type = "inter bloat ping pool";
    string t_op_arr = "[ ;";
    string t_add_arr = "[ ;";
    string add_t_mem = "inter bloat ping pool }";
    string base_prod = "inter bloat ping pool comp tower Identifier for while do if push }";
    string local_dec = "inter bloat ping pool comp tower";
    string local_var = "inter bloat ping pool";
    string lv_inter = "Identifier";
    string lv_int_tail = "= [ , ;";
    string lv_inter_value = "( inter bloat InterLiteral BloatLiteral Identifier";
    string math_expression = "( inter bloat InterLiteral BloatLiteral Identifier";
    string math_operand = "( inter bloat InterLiteral BloatLiteral Identifier";
    string math_tail_expression = "+ - * / % ; } , ) ]";
    string math_operator = "+ - * / %";
    string inter_conversion_value = "PingLiteral ( inter bloat InterLiteral BloatLiteral Identifier hold";
    string value_type = "[ . ( + - * / % ; } , ) ] = && || ! > < >= <= inter bloat ping pool comp tower Identifier for while do if push destroy commit {";
    string index_value = "( inter bloat InterLiteral BloatLiteral Identifier";
    string d2_value_type = "[ + - * / % ; } , ) ] = && || ! > < >= <= inter bloat ping pool comp tower Identifier for while do if push destroy commit {";
    string argument = "Identifier inter bloat pool ping )";
    string literal_value = "InterLiteral BloatLiteral PingLiteral PoolLiteral";
    string additional_args = ", )";
    string builtin_func_call = "inter pool ping";
    string l_inter_array_dec = "[";
    string l_inter_1d_tail = "= [ , ;";
    string l_inter_element = "( inter bloat InterLiteral BloatLiteral Identifier";
    string l_add_inter_1d = ", }";
    string l_inter_2d_tail = "= , ;";
    string l_add_inter_2d = ", }";
    string add_lv_inter_tail = ", ;";
    string lv_bloat = "Identifier";
    string lv_bloat_tail = "= [ , ;";
    string lv_bloat_value = "( inter bloat InterLiteral BloatLiteral Identifier";
    string bloat_conversion_value = "PingLiteral ( inter bloat InterLiteral BloatLiteral Identifier hold";
    string bloat_array_dec = "[";
    string l_bloat_1d_tail = "= [ , ;";
    string l_bloat_element = "( inter bloat InterLiteral BloatLiteral Identifier";
    string l_add_bloat_1d = ", }";
    string l_bloat_2d_tail = "= , ;";
    string l_add_bloat_2d = ", }";
    string add_lv_bloat_tail = ", ;";
    string lv_ping = "Identifier";
    string lv_ping_tail = "= [ , ;";
    string lv_ping_value = "ping hold Identifier PingLiteral InterLiteral BloatLiteral PoolLiteral";
    string ping_conversion_value = "Identifier PingLiteral InterLiteral BloatLiteral PoolLiteral";
    string string_concat = "Identifier PingLiteral";
    string string_value = "Identifier PingLiteral";
    string string_tail_concat = "+ , ; } )";
    string l_bloat_array_dec = "[";
    string l_ping_1d_tail = "= [ , ;";
    string l_ping_element = "ping hold Identifier PingLiteral";
    string l_add_ping_1d = ", }";
    string l_ping_2d_tail = "= , ;";
    string l_add_ping_2d = ", }";
    string add_lv_ping_tail = ", ;";
    string lv_pool = "Identifier";
    string lv_pool_tail = "= [ , ;";
    string lv_pool_value = "( ! inter bloat InterLiteral BloatLiteral PingLiteral buff debuff Identifier pool ping";
    string pool_conversion_value = "Identifier PoolLiteral PingLiteral hold";
    string pool_convert = "PingLiteral PoolLiteral";
    string general_expression = "( ! inter bloat InterLiteral BloatLiteral PingLiteral buff debuff Identifier pool ping";
    string general_operand = "( ! inter bloat InterLiteral BloatLiteral PingLiteral PoolLiteral Identifier pool ping";
    string general_tail_expression = " + - * / % && || == != > < >= <=  ; } , ) inter bloat ping pool comp tower Identifier for while do if push destroy commit {";
    string general_operator = "+ - * / % λ ( ! inter bloat InterLiteral BloatLiteral PingLiteral buff debuff Identifier pool ping && || == != > < >= <=";
    string l_pool_array_dec = "[";
    string l_pool_element = "( ! inter bloat InterLiteral BloatLiteral PingLiteral buff debuff Identifier pool ping";
    string l_pool_1D_tail = "[ , ;";
    string l_add_pool_1d = ", }";
    string l_pool_2d_tail = "= , ;";
    string l_add_pool_2d = ", }";
    string add_gv_pool_tail = ", ;";
    string local_comp = "comp";
    string lc_datatype = "inter bloat ping pool";
    string lc_inter_tail = "= [";
    string add_lc_inter_tail = ", ;";
    string lc_inter_array_dec = "[";
    string lc_inter_1d_tail = "= [";
    string lc_inter_2d_tail = "=";
    string lc_bloat_tail = "= [";
    string add_lc_bloat_tail = ", ;";
    string lc_bloat_array_dec = "[";
    string lc_bloat_1d_tail = "= [";
    string lc_bloat_2d_tail = "=";
    string lc_ping_tail = "= [";
    string add_lc_ping_tail = ", ;";
    string lc_ping_array_dec = "[";
    string lc_ping_1d_tail = "= [";
    string lc_ping_2d_tail = "=";
    string lc_pool_tail = "= [";
    string add_lc_pool_tail = ", ;";
    string lc_pool_array_dec = "[";
    string lc_pool_1d_tail = "= [";
    string lc_pool_2d_tail = "=";
    string local_tower = "tower";
    string statement = "Identifier for while do if push";
    string stm_type = "[ . ; (";
    string assign_value_type = "[ . =";
    string assignment = "=";
    string assign_value = "hold ( ! inter bloat InterLiteral BloatLiteral PingLiteral buff debuff Identifier pool ping {";
    string d1_2d_array = "( ! inter bloat InterLiteral BloatLiteral PingLiteral PoolLiteral Identifier pool ping";
    string assign_array_element = "( ! inter bloat InterLiteral BloatLiteral PingLiteral PoolLiteral Identifier pool ping";
    string add_assign_1d = ", }";
    string add_assign_2d = ", }";
    string loop_stm = "for while do";
    string lower_bound = "Identifier";
    string upper_bound = "Identifier";
    string content = "inter bloat ping pool comp tower Identifier for while do if push destroy commit }";
    string condition =  " ( ! inter bloat InterLiteral BloatLiteral PingLiteral buff debuff Identifier pool ping";
    string loop_terminator = "destroy commit";
    string cond_stm = "if";
    string body = "inter bloat ping pool comp tower Identifier for while do if push destroy commit {";
    string content_oneline = "destroy commit  inter bloat ping pool comp tower Identifier for while do if push";
    string else_clause = "else inter bloat ping pool comp tower Identifier for while do if push } destroy commit else recall";
    string push_value = "Identifier PingLiteral ping )";
    string user_function = "spawn";
    string spawn_tail = "inter bloat ping pool void";
    string parameter = "inter bloat ping pool )";
    string additional_param = ", )";
    string data_type = "inter bloat ping pool";
    string user_body = "inter bloat ping pool comp tower Identifier for while do if push recall }";
    string inter_recall = "( inter bloat InterLiteral BloatLiteral Identifier";
    string bloat_recall = "( inter bloat InterLiteral BloatLiteral Identifier";
    string ping_recall = "( Identifier PingLiteral ping";
    string ping_recall_value = "Identifier PingLiteral ping";
    string pool_recall = "( ! inter bloat InterLiteral BloatLiteral PingLiteral PoolLiteral Identifier pool ping";

    public string GetPredictSet(int code)
    {
        switch (code)
        {
            case 2001: return start;
            case 2002: return program;
            case 2003: return global_dec;
            case 2004: return global_var;
            case 2005: return gv_inter;
            case 2006: return gv_inter_tail;
            case 2007: return g_inter_array_dec;
            case 2008: return g_inter_1d_tail;
            case 2009: return g_inter_element;
            case 2010: return g_add_inter_1d;
            case 2011: return g_inter_2d_tail;
            case 2012: return g_add_inter_2d;
            case 2013: return add_gv_inter_tail;
            case 2014: return gv_bloat;
            case 2015: return gv_bloat_tail;
            case 2016: return g_bloat_array_dec;
            case 2017: return g_bloat_1d_tail;
            case 2018: return g_bloat_element;
            case 2019: return g_add_bloat_1d;
            case 2020: return g_bloat_2d_tail;
            case 2021: return g_add_bloat_2d;
            case 2022: return add_gv_bloat_tail;
            case 2023: return gv_ping;
            case 2024: return g_ping_tail;
            case 2025: return g_ping_array_dec;
            case 2026: return g_ping_1d_tail;
            case 2027: return g_ping_element;
            case 2028: return g_add_ping_1d;
            case 2029: return g_ping_2d_tail;
            case 2030: return g_add_ping_2d;
            case 2031: return g_ping_add;
            case 2032: return gv_pool;
            case 2033: return g_pool_tail;
            case 2034: return g_pool_array_dec;
            case 2035: return g_pool_1d_tail;
            case 2036: return g_pool_element;
            case 2037: return g_add_pool_1d;
            case 2038: return g_pool_2d_tail;
            case 2039: return g_add_pool_2d;
            case 2040: return g_pool_add;
            case 2041: return global_comp;
            case 2042: return gc_datatype;
            case 2043: return gc_inter_tail;
            case 2044: return add_gc_inter_tail;
            case 2045: return gc_inter_array_dec;
            case 2046: return gc_inter_1d_tail;
            case 2047: return gc_inter_2d_tail;
            case 2048: return gc_bloat_tail;
            case 2049: return add_gc_bloat_tail;
            case 2050: return gc_bloat_array_dec;
            case 2051: return gc_bloat_1d_tail;
            case 2052: return gc_bloat_2d_tail;
            case 2053: return gc_ping_tail;
            case 2054: return add_gc_ping_tail;
            case 2055: return gc_ping_array_dec;
            case 2056: return gc_ping_1d_tail;
            case 2057: return gc_ping_2d_tail;
            case 2058: return gc_pool_tail;
            case 2059: return add_gc_pool_tail;
            case 2060: return gc_pool_array_dec;
            case 2061: return gc_pool_1d_tail;
            case 2062: return gc_pool_2d_tail;
            case 2063: return global_tower;
            case 2064: return tower_var;
            case 2065: return t_member_type;
            case 2066: return t_op_arr;
            case 2067: return t_add_arr;
            case 2068: return add_t_mem;
            case 2069: return base_prod;
            case 2070: return local_dec;
            case 2071: return local_var;
            case 2072: return lv_inter;
            case 2073: return lv_int_tail;
            case 2074: return lv_inter_value;
            case 2075: return math_expression;
            case 2076: return math_operand;
            case 2077: return math_tail_expression;
            case 2078: return math_operator;
            case 2079: return inter_conversion_value;
            case 2080: return value_type;
            case 2081: return index_value;
            case 2082: return d2_value_type;
            case 2083: return argument;
            case 2084: return literal_value;
            case 2085: return additional_args;
            case 2086: return builtin_func_call;
            case 2087: return l_inter_array_dec;
            case 2088: return l_inter_1d_tail;
            case 2089: return l_inter_element;
            case 2090: return l_add_inter_1d;
            case 2091: return l_inter_2d_tail;
            case 2092: return l_add_inter_2d;
            case 2093: return add_lv_inter_tail;
            case 2094: return lv_bloat;
            case 2095: return lv_bloat_tail;
            case 2096: return lv_bloat_value;
            case 2097: return bloat_conversion_value;
            case 2098: return bloat_array_dec;
            case 2099: return l_bloat_1d_tail;
            case 2100: return l_bloat_element;
            case 2101: return l_add_bloat_1d;
            case 2102: return l_bloat_2d_tail;
            case 2103: return l_add_bloat_2d;
            case 2104: return add_lv_bloat_tail;
            case 2105: return lv_ping;
            case 2106: return lv_ping_tail;
            case 2107: return lv_ping_value;
            case 2108: return ping_conversion_value;
            case 2109: return string_concat;
            case 2110: return string_value;
            case 2111: return string_tail_concat;
            case 2112: return l_bloat_array_dec;
            case 2113: return l_ping_1d_tail;
            case 2114: return l_ping_element;
            case 2115: return l_add_ping_1d;
            case 2116: return l_ping_2d_tail;
            case 2117: return l_add_ping_2d;
            case 2118: return add_lv_ping_tail;
            case 2119: return lv_pool;
            case 2120: return lv_pool_tail;
            case 2121: return lv_pool_value;
            case 2122: return pool_conversion_value;
            case 2123: return pool_convert;
            case 2124: return general_expression;
            case 2125: return general_operand;
            case 2126: return general_tail_expression;
            case 2127: return general_operator;
            case 2128: return l_pool_array_dec;
            case 2129: return l_pool_element;
            case 2130: return l_pool_1D_tail;
            case 2131: return l_add_pool_1d;
            case 2132: return l_pool_2d_tail;
            case 2133: return l_add_pool_2d;
            case 2134: return add_gv_pool_tail;
            case 2135: return local_comp;
            case 2136: return lc_datatype;
            case 2137: return lc_inter_tail;
            case 2138: return add_lc_inter_tail;
            case 2139: return lc_inter_array_dec;
            case 2140: return lc_inter_1d_tail;
            case 2141: return lc_inter_2d_tail;
            case 2142: return lc_bloat_tail;
            case 2143: return add_lc_bloat_tail;
            case 2144: return lc_bloat_array_dec;
            case 2145: return lc_bloat_1d_tail;
            case 2146: return lc_bloat_2d_tail;
            case 2147: return lc_ping_tail;
            case 2148: return add_lc_ping_tail;
            case 2149: return lc_ping_array_dec;
            case 2150: return lc_ping_1d_tail;
            case 2151: return lc_ping_2d_tail;
            case 2152: return lc_pool_tail;
            case 2153: return add_lc_pool_tail;
            case 2154: return lc_pool_array_dec;
            case 2155: return lc_pool_1d_tail;
            case 2156: return lc_pool_2d_tail;
            case 2157: return local_tower;
            case 2158: return statement;
            case 2159: return stm_type;
            case 2160: return assign_value_type;
            case 2161: return assignment;
            case 2162: return assign_value;
            case 2163: return d1_2d_array;
            case 2164: return assign_array_element;
            case 2165: return add_assign_1d;
            case 2166: return add_assign_2d;
            case 2167: return loop_stm;
            case 2168: return lower_bound;
            case 2169: return upper_bound;
            case 2170: return content;
            case 2171: return condition;
            case 2172: return loop_terminator;
            case 2173: return cond_stm;
            case 2174: return body;
            case 2175: return content_oneline;
            case 2176: return else_clause;
            case 2177: return push_value;
            case 2178: return user_function;
            case 2179: return spawn_tail;
            case 2180: return parameter;
            case 2181: return additional_param;
            case 2182: return data_type;
            case 2183: return user_body;
            case 2184: return inter_recall;
            case 2185: return bloat_recall;
            case 2186: return ping_recall;
            case 2187: return ping_recall_value;
            case 2188: return pool_recall;

            default: return "";
        }
    }
}