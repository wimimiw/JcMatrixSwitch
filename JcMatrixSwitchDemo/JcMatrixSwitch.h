
#ifndef __JC_MATRIX_SWITCH_H__
#define __JC_MATRIX_SWITCH_H__

#define MATRIX_SWITCH_OK						(0 )
#define MATRIX_SWITCH_ERROR_INIT_EXCEPTION		(-1)
#define MATRIX_SWITCH_ERROR_INI_FILE_NOEXIST	(-2)
#define MATRIX_SWITCH_ERROR_OBJECT_NULL			(-3)
#define MATRIX_SWITCH_EXCUTE_FAILED				(-1)

#define COMM_TYPE_TCP		(2)
#define COMM_TYPE_UDP		(3)
#define COMM_TYPE_COM		(4)

#define ID_HUAWEI			(1)
#define ID_POI				(2)

/**********************************************************/
/*POI DEFINE*/
#define ID_SW1_SDT3			(1)   //开关类型1 ：操作范围<1~3>
#define ID_SW2_SDT3         (2)	  //开关类型2 ：操作范围<1~3>
#define ID_SW3_SDT4         (3)   //开关类型3 ：操作范围<1~4>
#define ID_SW4_SDT4         (4)   //开关类型4 ：操作范围<1~4>
#define ID_SW5_SDT7         (5)   //开关类型5 ：操作范围<1~7>
#define ID_SW6_SDT7         (6)   //开关类型6 ：操作范围<1~7>
#define ID_SW7_SDT2         (7)   //开关类型7 ：操作范围<1~2>
#define ID_SW8_SDT2         (8)   //开关类型8 ：操作范围<1~2>
#define ID_SW9_SDT2         (9)   //开关类型9 ：操作范围<1~2>
#define ID_SW10_SDT2        (10)  //开关类型10：操作范围<1~2>
#define ID_SW11_SDT2        (11)  //开关类型11：操作范围<1~2>
#define ID_SW12_SDT2        (12)  //开关类型12：操作范围<1~2>
//模块 
#define IP_Signalswich  	(1)
#define IP_Paspecumpwmt     (2)
#define IP_Testmdcdmagsm    (3)
#define IP_Testmdfdd18      (4)
#define IP_Testmdfdd21      (5)
#define IP_Testmdtdftda     (6)
#define IP_Testmdtdd23      (7)
//TX1
#define ID_1Cmgsmtx1        (1 )
#define ID_2Cucdmatx1       (2 )
#define ID_3Ctfd18tx1       (3 )
#define ID_4Cufd18tx1       (4 )
#define ID_5Ctfd21tx1       (5 )
#define ID_6Cuw21tx1        (6 )
#define ID_7Cmdcstx1        (7 )
#define ID_8Cmtdftx1        (8 )
#define ID_10Cmtdetx1       (9 )
#define ID_11Cttdetx1       (10)
//TX2                      
#define ID_1Cmgsmtx2        (1 )
#define ID_2Cucdmatx2       (2 )
#define ID_3Ctfd18tx2       (3 )
#define ID_4Cufd18tx2       (4 )
#define ID_5Ctfd21tx2       (5 )
#define ID_6Cuw21tx2        (6 )
#define ID_7Cmdcstx2        (7 )
#define ID_8Cmtdftx2        (8 )
#define ID_9Cmtdatx2        (9 )
#define ID_10Cmtdetx2       (10)
#define ID_12Cutdetx2       (11)
//RX                       
#define ID_gsmpim 	        (1 )
#define ID_cdmapim          (2 )
#define ID_ctfd18pim        (3 )
#define ID_cufd18pim        (4 )
#define ID_ctfd21pim        (5 )
#define ID_cuw21pim         (6 )
#define ID_cmdcspim         (7 )
#define ID_cmtdfpim         (8 )
#define ID_cmtde23pim       (9 )
#define ID_cttde23pim       (10)
//Coup
#define ID_Cdmagsmcp1       (1 )
#define ID_Cdmagsmcp2       (2 )
#define ID_fdd18cp1         (3 )
#define ID_fdd18cp2         (4 )
#define ID_fdd21cp1         (5 )
#define ID_fdd21cp2         (6 )
#define ID_tdftdacp1        (7 )
#define ID_tdftdacp2        (8 )
#define ID_tdftdacp3        (9 )
#define ID_tde23cp1	        (10)
#define ID_tde23cp2         (11)
/**********************************************************/

//函数指针类型
typedef int(*pMartrixSwitchInit)(int, char*, int, int);
typedef int(*pMartrixSwitchExcute)(int, int, int);
typedef int(*pMartrixSwitchBoxExcute)(int, int, int, int);
typedef int(*pMartrixSwitchDispose)();

int MartrixSwitchInit(int handle, char*dllName, int swType, int comType);
int MartrixSwitchBoxExcute(int tx1, int tx2, int pim, int det);
int MartrixSwitchExcute(int addr, int swId, int swIdx);
int MartrixSwitchDispose();


#endif