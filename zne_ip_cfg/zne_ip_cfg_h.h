

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Mon Aug 31 14:29:22 2015
 */
/* Compiler settings for zne_ip_cfg.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 7.00.0555 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__


#ifndef __zne_ip_cfg_h_h__
#define __zne_ip_cfg_h_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __Izne_ip_cfg_FWD_DEFINED__
#define __Izne_ip_cfg_FWD_DEFINED__
typedef interface Izne_ip_cfg Izne_ip_cfg;
#endif 	/* __Izne_ip_cfg_FWD_DEFINED__ */


#ifndef __zne_ip_cfg_FWD_DEFINED__
#define __zne_ip_cfg_FWD_DEFINED__

#ifdef __cplusplus
typedef class zne_ip_cfg zne_ip_cfg;
#else
typedef struct zne_ip_cfg zne_ip_cfg;
#endif /* __cplusplus */

#endif 	/* __zne_ip_cfg_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __zne_ip_cfg_LIBRARY_DEFINED__
#define __zne_ip_cfg_LIBRARY_DEFINED__

/* library zne_ip_cfg */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_zne_ip_cfg;

#ifndef __Izne_ip_cfg_DISPINTERFACE_DEFINED__
#define __Izne_ip_cfg_DISPINTERFACE_DEFINED__

/* dispinterface Izne_ip_cfg */
/* [uuid] */ 


EXTERN_C const IID DIID_Izne_ip_cfg;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("E911E8BA-93F0-40F8-8240-AC098A1B3C8B")
    Izne_ip_cfg : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct Izne_ip_cfgVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            Izne_ip_cfg * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            Izne_ip_cfg * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            Izne_ip_cfg * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            Izne_ip_cfg * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            Izne_ip_cfg * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            Izne_ip_cfg * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            Izne_ip_cfg * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } Izne_ip_cfgVtbl;

    interface Izne_ip_cfg
    {
        CONST_VTBL struct Izne_ip_cfgVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define Izne_ip_cfg_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define Izne_ip_cfg_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define Izne_ip_cfg_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define Izne_ip_cfg_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define Izne_ip_cfg_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define Izne_ip_cfg_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define Izne_ip_cfg_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __Izne_ip_cfg_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_zne_ip_cfg;

#ifdef __cplusplus

class DECLSPEC_UUID("D605316E-743B-491B-969D-5ED551929DA9")
zne_ip_cfg;
#endif
#endif /* __zne_ip_cfg_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


