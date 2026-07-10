#define ICALL_TABLE_corlib 1

static int corlib_icall_indexes [] = {
250,
263,
264,
265,
266,
267,
268,
269,
270,
271,
274,
275,
276,
455,
456,
457,
485,
486,
487,
514,
515,
516,
633,
634,
635,
638,
683,
684,
685,
686,
687,
688,
693,
695,
697,
699,
705,
713,
714,
715,
716,
717,
718,
719,
720,
721,
722,
723,
724,
725,
726,
727,
728,
729,
731,
732,
733,
734,
735,
736,
737,
838,
839,
840,
841,
842,
843,
844,
845,
846,
847,
848,
849,
850,
851,
852,
853,
854,
856,
857,
858,
859,
860,
861,
862,
924,
933,
934,
1006,
1013,
1016,
1018,
1023,
1024,
1026,
1027,
1031,
1032,
1034,
1035,
1038,
1039,
1040,
1043,
1045,
1048,
1050,
1052,
1061,
1130,
1132,
1134,
1144,
1145,
1146,
1148,
1154,
1155,
1156,
1157,
1158,
1166,
1167,
1168,
1172,
1173,
1175,
1179,
1180,
1181,
1478,
1671,
1672,
10170,
10171,
10173,
10174,
10175,
10176,
10177,
10179,
10180,
10181,
10182,
10200,
10202,
10210,
10212,
10214,
10216,
10219,
10269,
10270,
10272,
10273,
10274,
10275,
10276,
10278,
10280,
11449,
11453,
11455,
11456,
11457,
11458,
11911,
11912,
11913,
11914,
11932,
11933,
11934,
11982,
12067,
12070,
12078,
12079,
12080,
12081,
12082,
12430,
12431,
12436,
12437,
12474,
12520,
12527,
12534,
12545,
12549,
12575,
12659,
12661,
12672,
12674,
12675,
12676,
12683,
12698,
12718,
12719,
12727,
12729,
12736,
12737,
12740,
12742,
12747,
12753,
12754,
12761,
12763,
12775,
12778,
12779,
12780,
12791,
12801,
12807,
12808,
12809,
12811,
12812,
12829,
12831,
12846,
12869,
12870,
12871,
12896,
12901,
12931,
12932,
13585,
13606,
13694,
13695,
13966,
13967,
13975,
13976,
13977,
13983,
14055,
14829,
14830,
15454,
15455,
15456,
15462,
15472,
16513,
16534,
16536,
16538,
};
void ves_icall_System_Array_InternalCreate (int,int,int,int,int);
int ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal (int);
int ves_icall_System_Array_IsValueOfElementTypeInternal (int,int);
int ves_icall_System_Array_CanChangePrimitive (int,int,int);
int ves_icall_System_Array_FastCopy (int,int,int,int,int);
int ves_icall_System_Array_GetLengthInternal_raw (int,int,int);
int ves_icall_System_Array_GetLowerBoundInternal_raw (int,int,int);
void ves_icall_System_Array_GetGenericValue_icall (int,int,int);
void ves_icall_System_Array_GetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_SetGenericValue_icall (int,int,int);
void ves_icall_System_Array_SetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_InitializeInternal_raw (int,int);
void ves_icall_System_Array_SetValueRelaxedImpl_raw (int,int,int,int);
void ves_icall_System_Runtime_RuntimeImports_ZeroMemory (int,int);
void ves_icall_System_Runtime_RuntimeImports_Memmove (int,int,int);
void ves_icall_System_Buffer_BulkMoveWithWriteBarrier (int,int,int,int);
int ves_icall_System_Delegate_AllocDelegateLike_internal_raw (int,int);
int ves_icall_System_Delegate_CreateDelegate_internal_raw (int,int,int,int,int);
int ves_icall_System_Delegate_GetVirtualMethod_internal_raw (int,int);
void ves_icall_System_Enum_GetEnumValuesAndNames_raw (int,int,int,int);
int ves_icall_System_Enum_InternalGetCorElementType (int);
void ves_icall_System_Enum_InternalGetUnderlyingType_raw (int,int,int);
int ves_icall_System_Environment_get_ProcessorCount ();
int ves_icall_System_Environment_get_TickCount ();
int64_t ves_icall_System_Environment_get_TickCount64 ();
void ves_icall_System_Environment_FailFast_raw (int,int,int,int);
int ves_icall_System_GC_GetCollectionCount (int);
int ves_icall_System_GC_GetMaxGeneration ();
void ves_icall_System_GC_InternalCollect (int);
void ves_icall_System_GC_register_ephemeron_array_raw (int,int);
int ves_icall_System_GC_get_ephemeron_tombstone_raw (int);
int64_t ves_icall_System_GC_GetTotalAllocatedBytes_raw (int,int);
void ves_icall_System_GC_SuppressFinalize_raw (int,int);
void ves_icall_System_GC_ReRegisterForFinalize_raw (int,int);
void ves_icall_System_GC_GetGCMemoryInfo (int,int,int,int,int,int);
int ves_icall_System_GC_AllocPinnedArray_raw (int,int,int);
int ves_icall_System_Object_MemberwiseClone_raw (int,int);
double ves_icall_System_Math_Acos (double);
double ves_icall_System_Math_Acosh (double);
double ves_icall_System_Math_Asin (double);
double ves_icall_System_Math_Asinh (double);
double ves_icall_System_Math_Atan (double);
double ves_icall_System_Math_Atan2 (double,double);
double ves_icall_System_Math_Atanh (double);
double ves_icall_System_Math_Cbrt (double);
double ves_icall_System_Math_Ceiling (double);
double ves_icall_System_Math_Cos (double);
double ves_icall_System_Math_Cosh (double);
double ves_icall_System_Math_Exp (double);
double ves_icall_System_Math_Floor (double);
double ves_icall_System_Math_Log (double);
double ves_icall_System_Math_Log10 (double);
double ves_icall_System_Math_Pow (double,double);
double ves_icall_System_Math_Sin (double);
double ves_icall_System_Math_Sinh (double);
double ves_icall_System_Math_Sqrt (double);
double ves_icall_System_Math_Tan (double);
double ves_icall_System_Math_Tanh (double);
double ves_icall_System_Math_FusedMultiplyAdd (double,double,double);
double ves_icall_System_Math_Log2 (double);
double ves_icall_System_Math_ModF (double,int);
float ves_icall_System_MathF_Acos (float);
float ves_icall_System_MathF_Acosh (float);
float ves_icall_System_MathF_Asin (float);
float ves_icall_System_MathF_Asinh (float);
float ves_icall_System_MathF_Atan (float);
float ves_icall_System_MathF_Atan2 (float,float);
float ves_icall_System_MathF_Atanh (float);
float ves_icall_System_MathF_Cbrt (float);
float ves_icall_System_MathF_Ceiling (float);
float ves_icall_System_MathF_Cos (float);
float ves_icall_System_MathF_Cosh (float);
float ves_icall_System_MathF_Exp (float);
float ves_icall_System_MathF_Floor (float);
float ves_icall_System_MathF_Log (float);
float ves_icall_System_MathF_Log10 (float);
float ves_icall_System_MathF_Pow (float,float);
float ves_icall_System_MathF_Sin (float);
float ves_icall_System_MathF_Sinh (float);
float ves_icall_System_MathF_Sqrt (float);
float ves_icall_System_MathF_Tan (float);
float ves_icall_System_MathF_Tanh (float);
float ves_icall_System_MathF_FusedMultiplyAdd (float,float,float);
float ves_icall_System_MathF_Log2 (float);
float ves_icall_System_MathF_ModF (float,int);
int ves_icall_RuntimeMethodHandle_GetFunctionPointer_raw (int,int);
void ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw (int,int,int);
void ves_icall_RuntimeMethodHandle_ReboxToNullable_raw (int,int,int,int);
int ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw (int,int,int);
void ves_icall_RuntimeType_make_array_type_raw (int,int,int,int);
void ves_icall_RuntimeType_make_byref_type_raw (int,int,int);
void ves_icall_RuntimeType_make_pointer_type_raw (int,int,int);
void ves_icall_RuntimeType_MakeGenericType_raw (int,int,int,int);
int ves_icall_RuntimeType_GetMethodsByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetPropertiesByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetConstructors_native_raw (int,int,int);
int ves_icall_System_RuntimeType_CreateInstanceInternal_raw (int,int);
void ves_icall_RuntimeType_GetDeclaringMethod_raw (int,int,int);
void ves_icall_System_RuntimeType_getFullName_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetGenericArgumentsInternal_raw (int,int,int,int);
int ves_icall_RuntimeType_GetGenericParameterPosition (int);
int ves_icall_RuntimeType_GetEvents_native_raw (int,int,int,int);
int ves_icall_RuntimeType_GetFields_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetInterfaces_raw (int,int,int);
int ves_icall_RuntimeType_GetNestedTypes_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringType_raw (int,int,int);
void ves_icall_RuntimeType_GetName_raw (int,int,int);
void ves_icall_RuntimeType_GetNamespace_raw (int,int,int);
int ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetAttributes (int);
int ves_icall_RuntimeTypeHandle_GetMetadataToken_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_GetCorElementType (int);
int ves_icall_RuntimeTypeHandle_HasInstantiation (int);
int ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_HasReferences_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetArrayRank_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetAssembly_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetElementType_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetModule_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetBaseType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition (int);
int ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw (int,int);
int ves_icall_RuntimeTypeHandle_is_subclass_of_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsByRefLike_raw (int,int);
void ves_icall_System_RuntimeTypeHandle_internal_from_name_raw (int,int,int,int,int,int);
int ves_icall_System_String_FastAllocateString_raw (int,int);
int ves_icall_System_String_InternalIsInterned_raw (int,int);
int ves_icall_System_String_InternalIntern_raw (int,int);
int ves_icall_System_Type_internal_from_handle_raw (int,int);
int ves_icall_System_ValueType_InternalGetHashCode_raw (int,int,int);
int ves_icall_System_ValueType_Equals_raw (int,int,int,int);
int ves_icall_System_Threading_Interlocked_CompareExchange_Int (int,int,int);
void ves_icall_System_Threading_Interlocked_CompareExchange_Object (int,int,int,int);
int ves_icall_System_Threading_Interlocked_Decrement_Int (int);
int ves_icall_System_Threading_Interlocked_Increment_Int (int);
int64_t ves_icall_System_Threading_Interlocked_Increment_Long (int);
int ves_icall_System_Threading_Interlocked_Exchange_Int (int,int);
void ves_icall_System_Threading_Interlocked_Exchange_Object (int,int,int);
int64_t ves_icall_System_Threading_Interlocked_CompareExchange_Long (int,int64_t,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Exchange_Long (int,int64_t);
int ves_icall_System_Threading_Interlocked_Add_Int (int,int);
int64_t ves_icall_System_Threading_Interlocked_Add_Long (int,int64_t);
void ves_icall_System_Threading_Monitor_Monitor_Enter_raw (int,int);
void mono_monitor_exit_icall_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw (int,int);
int ves_icall_System_Threading_Monitor_Monitor_wait_raw (int,int,int,int);
void ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw (int,int,int,int,int);
int64_t ves_icall_System_Threading_Monitor_Monitor_get_lock_contention_count ();
void ves_icall_System_Threading_Thread_InitInternal_raw (int,int);
int ves_icall_System_Threading_Thread_GetCurrentThread ();
void ves_icall_System_Threading_InternalThread_Thread_free_internal_raw (int,int);
int ves_icall_System_Threading_Thread_GetState_raw (int,int);
void ves_icall_System_Threading_Thread_SetState_raw (int,int,int);
void ves_icall_System_Threading_Thread_ClrState_raw (int,int,int);
void ves_icall_System_Threading_Thread_SetName_icall_raw (int,int,int,int);
int ves_icall_System_Threading_Thread_YieldInternal ();
void ves_icall_System_Threading_Thread_SetPriority_raw (int,int,int);
void ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw (int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw (int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw (int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw (int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw (int);
int ves_icall_System_GCHandle_InternalAlloc_raw (int,int,int);
void ves_icall_System_GCHandle_InternalFree_raw (int,int);
int ves_icall_System_GCHandle_InternalGet_raw (int,int);
void ves_icall_System_GCHandle_InternalSet_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError ();
void ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError (int);
void ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw (int,int,int,int);
int ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw (int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw (int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw (int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack ();
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalBox_raw (int,int,int);
int ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw (int,int);
int ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_InternalLoad_raw (int,int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetType_raw (int,int,int,int,int,int);
int ves_icall_System_Reflection_AssemblyName_GetNativeName (int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw (int,int,int,int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw (int,int);
int ves_icall_MonoCustomAttrs_IsDefinedInternal_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw (int,int);
int ves_icall_System_Reflection_LoaderAllocatorScout_Destroy (int);
void ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw (int,int,int,int,int);
void ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw (int,int,int,int,int,int,int);
void ves_icall_RuntimeEventInfo_get_event_info_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_ResolveType_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetParentType_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_GetFieldOffset_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetValueInternal_raw (int,int,int);
void ves_icall_RuntimeFieldInfo_SetValueInternal_raw (int,int,int,int);
int ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw (int,int);
int ves_icall_reflection_get_token_raw (int,int);
void ves_icall_get_method_info_raw (int,int,int);
int ves_icall_get_method_attributes (int);
int ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw (int,int,int);
int ves_icall_System_MonoMethodInfo_get_retval_marshal_raw (int,int);
int ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw (int,int,int,int);
int ves_icall_RuntimeMethodInfo_get_name_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_base_method_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
void ves_icall_RuntimeMethodInfo_GetPInvoke_raw (int,int,int,int,int);
int ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw (int,int,int);
int ves_icall_RuntimeMethodInfo_GetGenericArguments_raw (int,int);
int ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw (int,int);
void ves_icall_InvokeClassConstructor_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw (int,int);
void ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw (int,int,int);
int ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw (int,int,int,int,int,int);
int ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw (int,int,int,int,int,int);
void ves_icall_RuntimePropertyInfo_get_property_info_raw (int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_CustomAttributeBuilder_GetBlob_raw (int,int,int,int,int,int,int,int);
void ves_icall_DynamicMethod_create_dynamic_method_raw (int,int,int,int,int);
void ves_icall_AssemblyBuilder_basic_init_raw (int,int);
void ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw (int,int);
void ves_icall_ModuleBuilder_basic_init_raw (int,int);
void ves_icall_ModuleBuilder_set_wrappers_type_raw (int,int,int);
int ves_icall_ModuleBuilder_getUSIndex_raw (int,int,int);
int ves_icall_ModuleBuilder_getToken_raw (int,int,int,int);
int ves_icall_ModuleBuilder_getMethodToken_raw (int,int,int,int);
void ves_icall_ModuleBuilder_RegisterToken_raw (int,int,int,int);
int ves_icall_TypeBuilder_create_runtime_class_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw (int,int);
int ves_icall_System_Diagnostics_Debugger_IsAttached_internal ();
int ves_icall_System_Diagnostics_Debugger_IsLogging ();
void ves_icall_System_Diagnostics_Debugger_Log (int,int,int);
int ves_icall_System_Diagnostics_StackFrame_GetFrameInfo (int,int,int,int,int,int,int,int);
void ves_icall_System_Diagnostics_StackTrace_GetTrace (int,int,int,int);
int ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass (int);
void ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree (int);
int ves_icall_Mono_SafeStringMarshal_StringToUtf8 (int);
void ves_icall_Mono_SafeStringMarshal_GFree (int);
static void *corlib_icall_funcs [] = {
// token 250,
ves_icall_System_Array_InternalCreate,
// token 263,
ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal,
// token 264,
ves_icall_System_Array_IsValueOfElementTypeInternal,
// token 265,
ves_icall_System_Array_CanChangePrimitive,
// token 266,
ves_icall_System_Array_FastCopy,
// token 267,
ves_icall_System_Array_GetLengthInternal_raw,
// token 268,
ves_icall_System_Array_GetLowerBoundInternal_raw,
// token 269,
ves_icall_System_Array_GetGenericValue_icall,
// token 270,
ves_icall_System_Array_GetValueImpl_raw,
// token 271,
ves_icall_System_Array_SetGenericValue_icall,
// token 274,
ves_icall_System_Array_SetValueImpl_raw,
// token 275,
ves_icall_System_Array_InitializeInternal_raw,
// token 276,
ves_icall_System_Array_SetValueRelaxedImpl_raw,
// token 455,
ves_icall_System_Runtime_RuntimeImports_ZeroMemory,
// token 456,
ves_icall_System_Runtime_RuntimeImports_Memmove,
// token 457,
ves_icall_System_Buffer_BulkMoveWithWriteBarrier,
// token 485,
ves_icall_System_Delegate_AllocDelegateLike_internal_raw,
// token 486,
ves_icall_System_Delegate_CreateDelegate_internal_raw,
// token 487,
ves_icall_System_Delegate_GetVirtualMethod_internal_raw,
// token 514,
ves_icall_System_Enum_GetEnumValuesAndNames_raw,
// token 515,
ves_icall_System_Enum_InternalGetCorElementType,
// token 516,
ves_icall_System_Enum_InternalGetUnderlyingType_raw,
// token 633,
ves_icall_System_Environment_get_ProcessorCount,
// token 634,
ves_icall_System_Environment_get_TickCount,
// token 635,
ves_icall_System_Environment_get_TickCount64,
// token 638,
ves_icall_System_Environment_FailFast_raw,
// token 683,
ves_icall_System_GC_GetCollectionCount,
// token 684,
ves_icall_System_GC_GetMaxGeneration,
// token 685,
ves_icall_System_GC_InternalCollect,
// token 686,
ves_icall_System_GC_register_ephemeron_array_raw,
// token 687,
ves_icall_System_GC_get_ephemeron_tombstone_raw,
// token 688,
ves_icall_System_GC_GetTotalAllocatedBytes_raw,
// token 693,
ves_icall_System_GC_SuppressFinalize_raw,
// token 695,
ves_icall_System_GC_ReRegisterForFinalize_raw,
// token 697,
ves_icall_System_GC_GetGCMemoryInfo,
// token 699,
ves_icall_System_GC_AllocPinnedArray_raw,
// token 705,
ves_icall_System_Object_MemberwiseClone_raw,
// token 713,
ves_icall_System_Math_Acos,
// token 714,
ves_icall_System_Math_Acosh,
// token 715,
ves_icall_System_Math_Asin,
// token 716,
ves_icall_System_Math_Asinh,
// token 717,
ves_icall_System_Math_Atan,
// token 718,
ves_icall_System_Math_Atan2,
// token 719,
ves_icall_System_Math_Atanh,
// token 720,
ves_icall_System_Math_Cbrt,
// token 721,
ves_icall_System_Math_Ceiling,
// token 722,
ves_icall_System_Math_Cos,
// token 723,
ves_icall_System_Math_Cosh,
// token 724,
ves_icall_System_Math_Exp,
// token 725,
ves_icall_System_Math_Floor,
// token 726,
ves_icall_System_Math_Log,
// token 727,
ves_icall_System_Math_Log10,
// token 728,
ves_icall_System_Math_Pow,
// token 729,
ves_icall_System_Math_Sin,
// token 731,
ves_icall_System_Math_Sinh,
// token 732,
ves_icall_System_Math_Sqrt,
// token 733,
ves_icall_System_Math_Tan,
// token 734,
ves_icall_System_Math_Tanh,
// token 735,
ves_icall_System_Math_FusedMultiplyAdd,
// token 736,
ves_icall_System_Math_Log2,
// token 737,
ves_icall_System_Math_ModF,
// token 838,
ves_icall_System_MathF_Acos,
// token 839,
ves_icall_System_MathF_Acosh,
// token 840,
ves_icall_System_MathF_Asin,
// token 841,
ves_icall_System_MathF_Asinh,
// token 842,
ves_icall_System_MathF_Atan,
// token 843,
ves_icall_System_MathF_Atan2,
// token 844,
ves_icall_System_MathF_Atanh,
// token 845,
ves_icall_System_MathF_Cbrt,
// token 846,
ves_icall_System_MathF_Ceiling,
// token 847,
ves_icall_System_MathF_Cos,
// token 848,
ves_icall_System_MathF_Cosh,
// token 849,
ves_icall_System_MathF_Exp,
// token 850,
ves_icall_System_MathF_Floor,
// token 851,
ves_icall_System_MathF_Log,
// token 852,
ves_icall_System_MathF_Log10,
// token 853,
ves_icall_System_MathF_Pow,
// token 854,
ves_icall_System_MathF_Sin,
// token 856,
ves_icall_System_MathF_Sinh,
// token 857,
ves_icall_System_MathF_Sqrt,
// token 858,
ves_icall_System_MathF_Tan,
// token 859,
ves_icall_System_MathF_Tanh,
// token 860,
ves_icall_System_MathF_FusedMultiplyAdd,
// token 861,
ves_icall_System_MathF_Log2,
// token 862,
ves_icall_System_MathF_ModF,
// token 924,
ves_icall_RuntimeMethodHandle_GetFunctionPointer_raw,
// token 933,
ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw,
// token 934,
ves_icall_RuntimeMethodHandle_ReboxToNullable_raw,
// token 1006,
ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw,
// token 1013,
ves_icall_RuntimeType_make_array_type_raw,
// token 1016,
ves_icall_RuntimeType_make_byref_type_raw,
// token 1018,
ves_icall_RuntimeType_make_pointer_type_raw,
// token 1023,
ves_icall_RuntimeType_MakeGenericType_raw,
// token 1024,
ves_icall_RuntimeType_GetMethodsByName_native_raw,
// token 1026,
ves_icall_RuntimeType_GetPropertiesByName_native_raw,
// token 1027,
ves_icall_RuntimeType_GetConstructors_native_raw,
// token 1031,
ves_icall_System_RuntimeType_CreateInstanceInternal_raw,
// token 1032,
ves_icall_RuntimeType_GetDeclaringMethod_raw,
// token 1034,
ves_icall_System_RuntimeType_getFullName_raw,
// token 1035,
ves_icall_RuntimeType_GetGenericArgumentsInternal_raw,
// token 1038,
ves_icall_RuntimeType_GetGenericParameterPosition,
// token 1039,
ves_icall_RuntimeType_GetEvents_native_raw,
// token 1040,
ves_icall_RuntimeType_GetFields_native_raw,
// token 1043,
ves_icall_RuntimeType_GetInterfaces_raw,
// token 1045,
ves_icall_RuntimeType_GetNestedTypes_native_raw,
// token 1048,
ves_icall_RuntimeType_GetDeclaringType_raw,
// token 1050,
ves_icall_RuntimeType_GetName_raw,
// token 1052,
ves_icall_RuntimeType_GetNamespace_raw,
// token 1061,
ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw,
// token 1130,
ves_icall_RuntimeTypeHandle_GetAttributes,
// token 1132,
ves_icall_RuntimeTypeHandle_GetMetadataToken_raw,
// token 1134,
ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw,
// token 1144,
ves_icall_RuntimeTypeHandle_GetCorElementType,
// token 1145,
ves_icall_RuntimeTypeHandle_HasInstantiation,
// token 1146,
ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw,
// token 1148,
ves_icall_RuntimeTypeHandle_HasReferences_raw,
// token 1154,
ves_icall_RuntimeTypeHandle_GetArrayRank_raw,
// token 1155,
ves_icall_RuntimeTypeHandle_GetAssembly_raw,
// token 1156,
ves_icall_RuntimeTypeHandle_GetElementType_raw,
// token 1157,
ves_icall_RuntimeTypeHandle_GetModule_raw,
// token 1158,
ves_icall_RuntimeTypeHandle_GetBaseType_raw,
// token 1166,
ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw,
// token 1167,
ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition,
// token 1168,
ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw,
// token 1172,
ves_icall_RuntimeTypeHandle_is_subclass_of_raw,
// token 1173,
ves_icall_RuntimeTypeHandle_IsByRefLike_raw,
// token 1175,
ves_icall_System_RuntimeTypeHandle_internal_from_name_raw,
// token 1179,
ves_icall_System_String_FastAllocateString_raw,
// token 1180,
ves_icall_System_String_InternalIsInterned_raw,
// token 1181,
ves_icall_System_String_InternalIntern_raw,
// token 1478,
ves_icall_System_Type_internal_from_handle_raw,
// token 1671,
ves_icall_System_ValueType_InternalGetHashCode_raw,
// token 1672,
ves_icall_System_ValueType_Equals_raw,
// token 10170,
ves_icall_System_Threading_Interlocked_CompareExchange_Int,
// token 10171,
ves_icall_System_Threading_Interlocked_CompareExchange_Object,
// token 10173,
ves_icall_System_Threading_Interlocked_Decrement_Int,
// token 10174,
ves_icall_System_Threading_Interlocked_Increment_Int,
// token 10175,
ves_icall_System_Threading_Interlocked_Increment_Long,
// token 10176,
ves_icall_System_Threading_Interlocked_Exchange_Int,
// token 10177,
ves_icall_System_Threading_Interlocked_Exchange_Object,
// token 10179,
ves_icall_System_Threading_Interlocked_CompareExchange_Long,
// token 10180,
ves_icall_System_Threading_Interlocked_Exchange_Long,
// token 10181,
ves_icall_System_Threading_Interlocked_Add_Int,
// token 10182,
ves_icall_System_Threading_Interlocked_Add_Long,
// token 10200,
ves_icall_System_Threading_Monitor_Monitor_Enter_raw,
// token 10202,
mono_monitor_exit_icall_raw,
// token 10210,
ves_icall_System_Threading_Monitor_Monitor_pulse_raw,
// token 10212,
ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw,
// token 10214,
ves_icall_System_Threading_Monitor_Monitor_wait_raw,
// token 10216,
ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw,
// token 10219,
ves_icall_System_Threading_Monitor_Monitor_get_lock_contention_count,
// token 10269,
ves_icall_System_Threading_Thread_InitInternal_raw,
// token 10270,
ves_icall_System_Threading_Thread_GetCurrentThread,
// token 10272,
ves_icall_System_Threading_InternalThread_Thread_free_internal_raw,
// token 10273,
ves_icall_System_Threading_Thread_GetState_raw,
// token 10274,
ves_icall_System_Threading_Thread_SetState_raw,
// token 10275,
ves_icall_System_Threading_Thread_ClrState_raw,
// token 10276,
ves_icall_System_Threading_Thread_SetName_icall_raw,
// token 10278,
ves_icall_System_Threading_Thread_YieldInternal,
// token 10280,
ves_icall_System_Threading_Thread_SetPriority_raw,
// token 11449,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw,
// token 11453,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw,
// token 11455,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw,
// token 11456,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw,
// token 11457,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw,
// token 11458,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw,
// token 11911,
ves_icall_System_GCHandle_InternalAlloc_raw,
// token 11912,
ves_icall_System_GCHandle_InternalFree_raw,
// token 11913,
ves_icall_System_GCHandle_InternalGet_raw,
// token 11914,
ves_icall_System_GCHandle_InternalSet_raw,
// token 11932,
ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError,
// token 11933,
ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError,
// token 11934,
ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw,
// token 11982,
ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw,
// token 12067,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw,
// token 12070,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw,
// token 12078,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw,
// token 12079,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw,
// token 12080,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw,
// token 12081,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack,
// token 12082,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalBox_raw,
// token 12430,
ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw,
// token 12431,
ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw,
// token 12436,
ves_icall_System_Reflection_Assembly_InternalLoad_raw,
// token 12437,
ves_icall_System_Reflection_Assembly_InternalGetType_raw,
// token 12474,
ves_icall_System_Reflection_AssemblyName_GetNativeName,
// token 12520,
ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw,
// token 12527,
ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw,
// token 12534,
ves_icall_MonoCustomAttrs_IsDefinedInternal_raw,
// token 12545,
ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw,
// token 12549,
ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw,
// token 12575,
ves_icall_System_Reflection_LoaderAllocatorScout_Destroy,
// token 12659,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw,
// token 12661,
ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw,
// token 12672,
ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw,
// token 12674,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw,
// token 12675,
ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw,
// token 12676,
ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw,
// token 12683,
ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw,
// token 12698,
ves_icall_RuntimeEventInfo_get_event_info_raw,
// token 12718,
ves_icall_reflection_get_token_raw,
// token 12719,
ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw,
// token 12727,
ves_icall_RuntimeFieldInfo_ResolveType_raw,
// token 12729,
ves_icall_RuntimeFieldInfo_GetParentType_raw,
// token 12736,
ves_icall_RuntimeFieldInfo_GetFieldOffset_raw,
// token 12737,
ves_icall_RuntimeFieldInfo_GetValueInternal_raw,
// token 12740,
ves_icall_RuntimeFieldInfo_SetValueInternal_raw,
// token 12742,
ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw,
// token 12747,
ves_icall_reflection_get_token_raw,
// token 12753,
ves_icall_get_method_info_raw,
// token 12754,
ves_icall_get_method_attributes,
// token 12761,
ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw,
// token 12763,
ves_icall_System_MonoMethodInfo_get_retval_marshal_raw,
// token 12775,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw,
// token 12778,
ves_icall_RuntimeMethodInfo_get_name_raw,
// token 12779,
ves_icall_RuntimeMethodInfo_get_base_method_raw,
// token 12780,
ves_icall_reflection_get_token_raw,
// token 12791,
ves_icall_InternalInvoke_raw,
// token 12801,
ves_icall_RuntimeMethodInfo_GetPInvoke_raw,
// token 12807,
ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw,
// token 12808,
ves_icall_RuntimeMethodInfo_GetGenericArguments_raw,
// token 12809,
ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw,
// token 12811,
ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw,
// token 12812,
ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw,
// token 12829,
ves_icall_InvokeClassConstructor_raw,
// token 12831,
ves_icall_InternalInvoke_raw,
// token 12846,
ves_icall_reflection_get_token_raw,
// token 12869,
ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw,
// token 12870,
ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw,
// token 12871,
ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw,
// token 12896,
ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw,
// token 12901,
ves_icall_RuntimePropertyInfo_get_property_info_raw,
// token 12931,
ves_icall_reflection_get_token_raw,
// token 12932,
ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw,
// token 13585,
ves_icall_CustomAttributeBuilder_GetBlob_raw,
// token 13606,
ves_icall_DynamicMethod_create_dynamic_method_raw,
// token 13694,
ves_icall_AssemblyBuilder_basic_init_raw,
// token 13695,
ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw,
// token 13966,
ves_icall_ModuleBuilder_basic_init_raw,
// token 13967,
ves_icall_ModuleBuilder_set_wrappers_type_raw,
// token 13975,
ves_icall_ModuleBuilder_getUSIndex_raw,
// token 13976,
ves_icall_ModuleBuilder_getToken_raw,
// token 13977,
ves_icall_ModuleBuilder_getMethodToken_raw,
// token 13983,
ves_icall_ModuleBuilder_RegisterToken_raw,
// token 14055,
ves_icall_TypeBuilder_create_runtime_class_raw,
// token 14829,
ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw,
// token 14830,
ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw,
// token 15454,
ves_icall_System_Diagnostics_Debugger_IsAttached_internal,
// token 15455,
ves_icall_System_Diagnostics_Debugger_IsLogging,
// token 15456,
ves_icall_System_Diagnostics_Debugger_Log,
// token 15462,
ves_icall_System_Diagnostics_StackFrame_GetFrameInfo,
// token 15472,
ves_icall_System_Diagnostics_StackTrace_GetTrace,
// token 16513,
ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass,
// token 16534,
ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree,
// token 16536,
ves_icall_Mono_SafeStringMarshal_StringToUtf8,
// token 16538,
ves_icall_Mono_SafeStringMarshal_GFree,
};
static uint8_t corlib_icall_flags [] = {
0,
0,
0,
0,
0,
4,
4,
0,
4,
0,
4,
4,
4,
0,
0,
0,
4,
4,
4,
4,
0,
4,
0,
0,
0,
4,
0,
0,
0,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
0,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
};
