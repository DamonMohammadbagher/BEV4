using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEV4.Master_Value
{
    public class Large_String
    {

        #region All_Security_Events_Description_2
        public static string All_Security_Events_Description2 =
@"    value: 4608
    level: 4    
    message: Windows is starting up.
++This event is logged when LSASS.EXE starts and the auditing subsystem is initialized.++
  
    value: 4609
    level: 4
    message: Windows is shutting down.
++All logon sessions will be terminated by this shutdown.++
  
    value: 4610   
    level: 4   
    message: An authentication package has been loaded by the Local Security Authority.
++This authentication package will be used to authenticate logon attempts.++


    value: 4611  
    level: 4   
    message: A trusted logon process has been registered with the Local Security Authority.
++This logon process will be trusted to submit logon requests.++

    value: 4612
    level: 4
    message: Internal resources allocated for the queuing of audit messages have been exhausted, leading to the loss of some audits.
++This event is generated when audit queues are filled and events must be discarded.  This most commonly occurs when security events are being generated faster than they are being written to disk, or when the auditing system loses connectivity to the event log, such as when the event log service is stopped.++

    value: 4614
    level: 4
    message: A notification package has been loaded by the Security Account Manager.
++This package will be notified of any account or password changes.++

    value: 4615
    level: 4
    message: Invalid use of LPC port.
++Windows Local Security Authority (LSA) communicates with the Windows kernel using Local Procedure Call (LPC) ports. If you see this event, an application has inadvertently or intentionally accessed this port which is reserved exclusively for LSA's use. The application (process) should be investigated to ensure that it is not attempting to tamper with this communications channel.++
  
    value: 4616
    level: 4
    message: The system time was changed.
++This event is generated when the system time is changed. It is normal for the Windows Time Service, which runs with System privilege, to change the system time on a regular basis. Other system time changes may be indicative of attempts to tamper with the computer.++

    value: 4618
    level: 4
    message: A monitored security event pattern has occurred.
++This event is generated when Windows is configured to generate alerts in accordance with the Common Criteria Security Audit Analysis requirements (FAU_SAA) and an auditable event pattern occurs.++

    value: 4621
    level: 4
    message: Administrator recovered system from CrashOnAuditFail. Users who are not administrators will now be allowed to log on. Some auditable activity might not have been recorded.
++This event is logged after a system reboots following CrashOnAuditFail.++


    value: 4622
    level: 4
    message: A security package has been loaded by the Local Security Authority.
++++
    value: 4624
    level: 4
    message: An account was successfully logged on.

++This event is generated when a logon session is created. It is generated on the computer that was accessed.
The subject fields indicate the account on the local system which requested the logon. This is most commonly a service such as the Server service, or a local process such as Winlogon.exe or Services.exe.
The logon type field indicates the kind of logon that occurred. The most common types are 2 (interactive) and 3 (network).
The New Logon fields indicate the account for whom the new logon was created, i.e. the account that was logged on.
The network fields indicate where a remote logon request originated. Workstation name is not always available and may be left blank in some cases.
The authentication information fields provide detailed information about this specific logon request.
- Logon GUID is a unique identifier that can be used to correlate this event with a KDC event.
- Transited services indicate which intermediate services have participated in this logon request.
- Package name indicates which sub-protocol was used among the NTLM protocols.
- Key length indicates the length of the generated session key. This will be 0 if no session key was requested++

    value: 4625
    level: 4
    message: An account failed to log on.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Logon Type:			%11

Account For Which Logon Failed:
	Security ID:		%5
	Account Name:		%6
	Account Domain:		%7

Failure Information:
	Failure Reason:		%9
	Status:			%8
	Sub Status:		%10

Process Information:
	Caller Process ID:	%18
	Caller Process Name:	%19

Network Information:
	Workstation Name:	%14
	Source Network Address:	%20
	Source Port:		%21

Detailed Authentication Information:
	Logon Process:		%12
	Authentication Package:	%13
	Transited Services:	%15
	Package Name (NTLM only):	%16
	Key Length:		%17


++This event is generated when a logon request fails. It is generated on the computer where access was attempted.

The Subject fields indicate the account on the local system which requested the logon. This is most commonly a service such as the Server service, or a local process such as Winlogon.exe or Services.exe.

The Logon Type field indicates the kind of logon that was requested. The most common types are 2 (interactive) and 3 (network).

The Process Information fields indicate which account and process on the system requested the logon.

The Network Information fields indicate where a remote logon request originated. Workstation name is not always available and may be left blank in some cases.

The authentication information fields provide detailed information about this specific logon request.
	- Transited services indicate which intermediate services have participated in this logon request.
	- Package name indicates which sub-protocol was used among the NTLM protocols.
	- Key length indicates the length of the generated session key. This will be 0 if no session key was requested.++
  event:
    value: 4634
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An account was logged off.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Logon Type:			%5

++This event is generated when a logon session is destroyed. It may be positively correlated with a logon event using the Logon ID value. Logon IDs are only unique between reboots on the same computer++
  event:
    value: 4646
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: This event is generated when a logon session is destroyed.
++++
  event:
    value: 4647
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: User initiated logoff:
++++
Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

++This event is generated when a logoff is initiated but the token reference count is not zero and the logon session cannot be destroyed.  No further user-initiated activity can occur.  This event can be interpreted as a logoff event.++
  event:
    value: 4648
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A logon was attempted using explicit credentials.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4
	Logon GUID:		%5

Account Whose Credentials Were Used:
	Account Name:		%6
	Account Domain:		%7
	Logon GUID:		%8

Target Server:
	Target Server Name:	%9
	Additional Information:	%10

Process Information:
	Process ID:		%11
	Process Name:		%12

Network Information:
	Network Address:	%13
	Port:			%14

++This event is generated when a process attempts to log on an account by explicitly specifying that account’s credentials.  This most commonly occurs in batch-type configurations such as scheduled tasks, or when using the RUNAS command.++
  event:
    value: 4649
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A replay attack was detected.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Credentials Which Were Replayed:
	Account Name:		%5
	Account Domain:		%6

Process Information:
	Process ID:		%12
	Process Name:		%13

Network Information:
	Workstation Name:	%10

Detailed Authentication Information:
	Request Type:		%7
	Logon Process:		%8
	Authentication Package:	%9
	Transited Services:	%11

++This event indicates that a Kerberos replay attack was detected- a request was received twice with identical information. This condition could be caused by network misconfiguration.++
  event:
    value: 4650
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Main Mode security association was established. Extended Mode was not enabled.  Certificate authentication was not used.

Local Endpoint:
	Principal Name:	%1
	Network Address:	%3
	Keying Module Port:	%4

Remote Endpoint:
	Principal Name:	%2
	Network Address:	%5
	Keying Module Port:	%6

Security Association Information:
	Lifetime (minutes):	%12
	Quick Mode Limit:	%13
	Main Mode SA ID:	%17

Cryptographic Information:
	Cipher Algorithm:	%9
	Integrity Algorithm:	%10
	Diffie-Hellman Group:	%11

Additional Information:
	Keying Module Name:	%7
	Authentication Method:	%8
	Role:	%14
	Impersonation State:	%15
	Main Mode Filter ID:	%16
++++
  event:
    value: 4651
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Main Mode security association was established. Extended Mode was not enabled.  A certificate was used for authentication.

Local Endpoint:
	Principal Name:	%1
	Network Address:	%9
	Keying Module Port:	%10

Local Certificate:
	SHA Thumbprint:	%2
	Issuing CA:		%3
	Root CA:		%4

Remote Endpoint:
	Principal Name:	%5
	Network Address:	%11
	Keying Module Port:	%12

Remote Certificate:
	SHA thumbprint: 	%6
	Issuing CA:		%7
	Root CA:		%8

Cryptographic Information:
	Cipher Algorithm:	%15
	Integrity Algorithm:	%16
	Diffie-Hellman Group:	%17

Security Association Information:
	Lifetime (minutes):	%18
	Quick Mode Limit:	%19
	Main Mode SA ID:	%23

Additional Information:
	Keying Module Name:	%13
	Authentication Method:	%14
	Role:	%20
	Impersonation State:	%21
	Main Mode Filter ID:	%22
++++
  event:
    value: 4652
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Main Mode negotiation failed.


Local Endpoint:
	Principal Name:		%1
	Network Address:	%9
	Keying Module Port:	%10

Local Certificate:
	SHA Thumbprint:	%2
	Issuing CA:		%3
	Root CA:		%4

Remote Endpoint:
	Principal Name:		%5
	Network Address:	%11
	Keying Module Port:	%12

Remote Certificate:
	SHA thumbprint:		%6
	Issuing CA:		%7
	Root CA:		%8

Additional Information:
	Keying Module Name:	%13
	Authentication Method:	%16
	Role:			%18
	Impersonation State:	%19
	Main Mode Filter ID:	%20

Failure Information:
	Failure Point:		%14
	Failure Reason:		%15
	State:			%17
	Initiator Cookie:		%21
	Responder Cookie:	%22
++++
  event:
    value: 4653
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Main Mode negotiation failed.

Local Endpoint:
	Local Principal Name:	%1
	Network Address:	%3
	Keying Module Port:	%4

Remote Endpoint:
	Principal Name:		%2
	Network Address:	%5
	Keying Module Port:	%6

Additional Information:
	Keying Module Name:	%7
	Authentication Method:	%10
	Role:			%12
	Impersonation State:	%13
	Main Mode Filter ID:	%14

Failure Information:
	Failure Point:		%8
	Failure Reason:		%9
	State:			%11
	Initiator Cookie:		%15
	Responder Cookie:	%16
++++
  event:
    value: 4654
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Quick Mode negotiation failed.

Local Endpoint:
	Network Address:	%1
	Network Address mask:	%2
	Port:			%3
	Tunnel Endpoint:		%4

Remote Endpoint:
	Network Address:	%5
	Address Mask:		%6
	Port:			%7
	Tunnel Endpoint:		%8
	Private Address:		%10

Additional Information:
	Protocol:		%9
	Keying Module Name:	%11
	Mode:			%14
	Role:			%16
	Quick Mode Filter ID:	%18
	Main Mode SA ID:	%19

Failure Information:
	State:			%15
	Message ID:		%17
	Failure Point:		%12
	Failure Reason:		%13
  event:
++++
    value: 4655
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Main Mode security association ended.

Local Network Address:		%1
Remote Network Address:	%2
Keying Module Name:		%3
Main Mode SA ID:		%4
++++
  event:
    value: 4656
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A handle to an object was requested.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:		%5
	Object Type:		%6
	Object Name:		%7
	Handle ID:		%8

Process Information:
	Process ID:		%14
	Process Name:		%15

Access Request Information:
	Transaction ID:		%9
	Accesses:		%10
	Access Mask:		%11
	Privileges Used for Access Check:	%12
	Restricted SID Count:	%13
++++
  event:
    value: 4657
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A registry value was modified.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Name:		%5
	Object Value Name:	%6
	Handle ID:		%7
	Operation Type:		%8

Process Information:
	Process ID:		%13
	Process Name:		%14

Change Information:
	Old Value Type:		%9
	Old Value:		%10
	New Value Type:		%11
	New Value:		%12
++++
  event:
    value: 4658
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The handle to an object was closed.

Subject :
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:		%5
	Handle ID:		%6

Process Information:
	Process ID:		%7
	Process Name:		%8
++++
  event:
    value: 4659
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A handle to an object was requested with intent to delete.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:	%5
	Object Type:	%6
	Object Name:	%7
	Handle ID:	%8

Process Information:
	Process ID:	%13

Access Request Information:
	Transaction ID:	%9
	Accesses:	%10
	Access Mask:	%11
	Privileges Used for Access Check:	%12
++++
  event:

    value: 4660
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An object was deleted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:	%5
	Handle ID:	%6

Process Information:
	Process ID:	%7
	Process Name:	%8
	Transaction ID:	%9
++++
  event:

    value: 4661
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A handle to an object was requested.

Subject :
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:	%5
	Object Type:	%6
	Object Name:	%7
	Handle ID:	%8

Process Information:
	Process ID:	%15
	Process Name:	%16

Access Request Information:
	Transaction ID:	%9
	Accesses:	%10
	Access Mask:	%11
	Privileges Used for Access Check:	%12
	Properties:	%13
	Restricted SID Count:	%14
++++
  event:

    value: 4662
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An operation was performed on an object.

Subject :
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:		%5
	Object Type:		%6
	Object Name:		%7
	Handle ID:		%9

Operation:
	Operation Type:		%8
	Accesses:		%10
	Access Mask:		%11
	Properties:		%12

Additional Information:
	Parameter 1:		%13
	Parameter 2:		%14
++++
  event:

    value: 4663
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt was made to access an object.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:	%5
	Object Type:	%6
	Object Name:	%7
	Handle ID:	%8

Process Information:
	Process ID:	%11
	Process Name:	%12

Access Request Information:
	Accesses:	%9
	Access Mask:	%10
++++
  event:

    value: 4664
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt was made to create a hard link.

Subject:
	Account Name:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Link Information:
	File Name:	%5
	Link Name:	%6
	Transaction ID:	%7
++++
  event:
    value: 4665
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt was made to create an application client context.

Subject:
	Client Name:		%3
	Client Domain:		%4
	Client Context ID:	%5

Application Information:
	Application Name:	%1
	Application Instance ID:	%2

Status:	%6
++++
  event:
    value: 4666
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An application attempted an operation:

Subject:
	Client Name:		%5
	Client Domain:		%6
	Client Context ID:	%7

Object:
	Object Name:		%3
	Scope Names:		%4

Application Information:
	Application Name:	%1
	Application Instance ID:	%2

Access Request Information:
	Role:			%8
	Groups:			%9
	Operation Name:	%10 (%11)
++++
  event:
    value: 4667
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An application client context was deleted.

Subject:
	Client Name:		%3
	Client Domain:		%4
	Client Context ID:	%5

Application Information:
	Application Name:	%1
	Application Instance ID:	%2
++++
  event:
    value: 4668
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An application was initialized.

Subject:
	Client Name:	%3
	Client Domain:	%4
	Client ID:	%5

Application Information:
	Application Name:	%1
	Application Instance ID:	%2

Additional Information:
	Policy Store URL:	%6
++++
  event:
    value: 4670
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Permissions on an object were changed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:	%5
	Object Type:	%6
	Object Name:	%7
	Handle ID:	%8

Process:
	Process ID:	%11
	Process Name:	%12

Permissions Change:
	Original Security Descriptor:	%9
	New Security Descriptor:	%10
++++
  event:
    value: 4671
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An application attempted to access a blocked ordinal through the TBS.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Ordinal:	%5
++++
  event:
    value: 4672
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Special privileges assigned to new logon.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Privileges:		%5
++++
  event:
    value: 4673
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A privileged service was called.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Service:
	Server:	%5
	Service Name:	%6

Process:
	Process ID:	%8
	Process Name:	%9

Service Request Information:
	Privileges:		%7
++++
  event:
    value: 4674
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An operation was attempted on a privileged object.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:	%5
	Object Type:	%6
	Object Name:	%7
	Object Handle:	%8

Process Information:
	Process ID:	%11
	Process Name:	%12

Requested Operation:
	Desired Access:	%9
	Privileges:		%10
++++
  event:
    value: 4675
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: SIDs were filtered.

Target Account:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3

Trust Information:
	Trust Direction:	%4
	Trust Attributes:	%5
	Trust Type:	%6
	TDO Domain SID:	%7

Filtered SIDs:	%8
++++
  event:
    value: 4688
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A new process has been created.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Process Information:
	New Process ID:		%5
	New Process Name:	%6
	Token Elevation Type:	%7
	Creator Process ID:	%8

++Token Elevation Type indicates the type of token that was assigned to the new process in accordance with User Account Control policy.

Type 1 is a full token with no privileges removed or groups disabled.  A full token is only used if User Account Control is disabled or if the user is the built-in Administrator account or a service account.

Type 2 is an elevated token with no privileges removed or groups disabled.  An elevated token is used when User Account Control is enabled and the user chooses to start the program using Run as administrator.  An elevated token is also used when an application is configured to always require administrative privilege or to always require maximum privilege, and the user is a member of the Administrators group.

Type 3 is a limited token with administrative privileges removed and administrative groups disabled.  The limited token is used when User Account Control is enabled, the application does not require administrative privilege, and the user does not choose to start the program using Run as administrator.++
  event:
    value: 4689
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A process has exited.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Process Information:
	Process ID:	%6
	Process Name:	%7
	Exit Status:	%5
++++
  event:
    value: 4690
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt was made to duplicate a handle to an object.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Source Handle Information:
	Source Handle ID:	%5
	Source Process ID:	%6

New Handle Information:
	Target Handle ID:	%7
	Target Process ID:	%8
++++
  event:
    value: 4691
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Indirect access to an object was requested.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Type:	%5
	Object Name:	%6

Process Information:
	Process ID:	%9

Access Request Information:
	Accesses:	%7
	Access Mask:	%8
++++
  event:
    value: 4692
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Backup of data protection master key was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Key Information:
	Key Identifier:	%5
	Recovery Server:	%6
	Recovery Key ID:	%7

Status Information:
	Status Code:	%8
++++
  event:
    value: 4693
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Recovery of data protection master key was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Key Information:
	Key Identifier:	%5
	Recovery Server:	%6
	Recovery Key ID:	%8
	Recovery Reason:	%7

Status Information:
	Status Code:	%9
++++
  event:
    value: 4694
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Protection of auditable protected data was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Protected Data:
	Data Description:	%6
	Key Identifier:	%5
	Protected Data Flags:	%7
	Protection Algorithms:	%8

Status Information:
	Status Code:	%9
++++
  event:
    value: 4695
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Unprotection of auditable protected data was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Protected Data:
	Data Description:	%6
	Key Identifier:	%5
	Protected Data Flags:	%7
	Protection Algorithms:	%8

Status Information:
	Status Code:	%9
++++
  event:
    value: 4696
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A primary token was assigned to process.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Process Information:
	Process ID:	%11
	Process Name:	%12

Target Process:
	Target Process ID:	%9
	Target Process Name:	%10

New Token Information:
	Security ID:		%5
	Account Name:		%6
	Account Domain:		%7
	Logon ID:		%8
++++
  event:
    value: 4697
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A service was installed in the system.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Service Information:
	Service Name: 		%5
	Service File Name:	%6
	Service Type: 		%7
	Service Start Type:	%8
	Service Account: 		%9
++++
  event:
    value: 4698
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A scheduled task was created.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Task Information:
	Task Name: 		%5
	Task Content: 		%6
++++
	
  event:
    value: 4699
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A scheduled task was deleted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Task Information:
	Task Name: 		%5
	Task Content: 		%6
++++
	
  event:
    value: 4700
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A scheduled task was enabled.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Task Information:
	Task Name: 		%5
	Task Content: 		%6
++++
	
  event:
    value: 4701
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A scheduled task was disabled.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Task Information:
	Task Name: 		%5
	Task Content: 		%6
++++
	
  event:
    value: 4702
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A scheduled task was updated.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Task Information:
	Task Name: 		%5
	Task New Content: 		%6
++++
	
  event:
    value: 4704
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A user right was assigned.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Target Account:
	Account Name:		%5

New Right:
	User Right:		%6
++++
  event:
    value: 4705
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A user right was removed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Target Account:
	Account Name:		%5

Removed Right:
	User Right:		%6
++++
  event:
    value: 4706
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A new trust was created to a domain.

Subject:
	Security ID:		%3
	Account Name:		%4
	Account Domain:		%5
	Logon ID:		%6

Trusted Domain:
	Domain Name:		%1
	Domain ID:		%2

Trust Information:
	Trust Type:		%7
	Trust Direction:		%8
	Trust Attributes:		%9
	SID Filtering:		%10
++++
  event:
    value: 4707
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A trust to a domain was removed.

Subject:
	Security ID:		%3
	Account Name:		%4
	Account Domain:		%5
	Logon ID:		%6

Domain Information:
	Domain Name:		%1
	Domain ID:		%2
++++
  event:
    value: 4709
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Services was started.

%1

Policy Source: 	%2

%3
++++
  event:
    value: 4710
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Services was disabled.

%1
%2
++++
  event:
    value: 4711
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: %1
++++
  event:
    value: 4712
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Services encountered a potentially serious failure.
%1
++++
  event:
    value: 4713
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Kerberos policy was changed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Changes Made:
('--' means no changes, otherwise each change is shown as:
(Parameter Name):	(new value) (old value))
%5
++++
  event:
    value: 4714
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Encrypted data recovery policy was changed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Changes Made:
('--' means no changes, otherwise each change is shown as:
(Parameter Name):	(new value) (old value))
%5
++++
  event:
    value: 4715
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The audit policy (SACL) on an object was changed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain: 	%3
	Logon ID: 		%4

Audit Policy Change:
	Original Security Descriptor: 	%5
	New Security Descriptor: 		%6
++++
  event:
    value: 4716
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Trusted domain information was modified.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Trusted Domain:
	Domain Name:		%5
	Domain ID:		%6

New Trust Information:
	Trust Type:		%7
	Trust Direction:		%8
	Trust Attributes:		%9
	SID Filtering:		%10
++++
  event:
    value: 4717
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: System security access was granted to an account.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Account Modified:
	Account Name:		%5

Access Granted:
	Access Right:		%6
++++
  event:
    value: 4718
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: System security access was removed from an account.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Account Modified:
	Account Name:		%5

Access Removed:
	Access Right:		%6
++++
  event:
    value: 4719
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: System audit policy was changed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Audit Policy Change:
	Category:		%5
	Subcategory:		%6
	Subcategory GUID:	%7
	Changes:		%8
++++
  event:
    value: 4720
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A user account was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

New Account:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Attributes:
	SAM Account Name:	%9
	Display Name:		%10
	User Principal Name:	%11
	Home Directory:		%12
	Home Drive:		%13
	Script Path:		%14
	Profile Path:		%15
	User Workstations:	%16
	Password Last Set:	%17
	Account Expires:		%18
	Primary Group ID:	%19
	Allowed To Delegate To:	%20
	Old UAC Value:		%21
	New UAC Value:		%22
	User Account Control:	%23
	User Parameters:	%24
	SID History:		%25
	Logon Hours:		%26

Additional Information:
	Privileges		%8
++++
  event:
    value: 4722
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A user account was enabled.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Target Account:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2
++++
  event:
    value: 4723
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt was made to change an account's password.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Target Account:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Additional Information:
	Privileges		%8
++++
  event:
    value: 4724
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt was made to reset an account's password.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Target Account:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2
++++
  event:
    value: 4725
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A user account was disabled.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Target Account:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2
++++
  event:
    value: 4726
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A user account was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Target Account:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Additional Information:
	Privileges	%8
++++
  event:
    value: 4727
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-enabled global group was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

New Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4728
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was added to a security-enabled global group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4729
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was removed from a security-enabled global group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4730
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-enabled global group was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Deleted Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4731
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-enabled local group was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

New Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4732
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was added to a security-enabled local group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4733
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was removed from a security-enabled local group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4734
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-enabled local group was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4735
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-enabled local group was changed.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Changed Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4737
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-enabled global group was changed.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Changed Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4738
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A user account was changed.

Subject:
	Security ID:		%5
	Account Name:		%6
	Account Domain:		%7
	Logon ID:		%8

Target Account:
	Security ID:		%4
	Account Name:		%2
	Account Domain:		%3

Changed Attributes:
	SAM Account Name:	%10
	Display Name:		%11
	User Principal Name:	%12
	Home Directory:		%13
	Home Drive:		%14
	Script Path:		%15
	Profile Path:		%16
	User Workstations:	%17
	Password Last Set:	%18
	Account Expires:		%19
	Primary Group ID:	%20
	AllowedToDelegateTo:	%21
	Old UAC Value:		%22
	New UAC Value:		%23
	User Account Control:	%24
	User Parameters:	%25
	SID History:		%26
	Logon Hours:		%27

Additional Information:
	Privileges:		%9
++++
  event:
    value: 4739
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Domain Policy was changed.

Change Type:		%1 modified

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Domain:
	Domain Name:		%2
	Domain ID:		%3

Changed Attributes:
	Min. Password Age:	%9
	Max. Password Age:	%10
	Force Logoff:		%11
	Lockout Threshold:	%12
	Lockout Observation Window:	%13
	Lockout Duration:	%14
	Password Properties:	%15
	Min. Password Length:	%16
	Password History Length:	%17
	Machine Account Quota:	%18
	Mixed Domain Mode:	%19
	Domain Behavior Version:	%20
	OEM Information:	%21

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4740
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A user account was locked out.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Account That Was Locked Out:
	Security ID:		%3
	Account Name:		%1

Additional Information:
	Caller Computer Name:	%2
++++
  event:
    value: 4741
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A computer account was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

New Computer Account:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Attributes:
	SAM Account Name:	%9
	Display Name:		%10
	User Principal Name:	%11
	Home Directory:		%12
	Home Drive:		%13
	Script Path:		%14
	Profile Path:		%15
	User Workstations:	%16
	Password Last Set:	%17
	Account Expires:		%18
	Primary Group ID:	%19
	AllowedToDelegateTo:	%20
	Old UAC Value:		%21
	New UAC Value:		%22
	User Account Control:	%23
	User Parameters:	%24
	SID History:		%25
	Logon Hours:		%26
	DNS Host Name:		%27
	Service Principal Names:	%28

Additional Information:
	Privileges		%8
++++
  event:
    value: 4742
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A computer account was changed.

Subject:
	Security ID:		%5
	Account Name:		%6
	Account Domain:		%7
	Logon ID:		%8

Computer Account That Was Changed:
	Security ID:		%4
	Account Name:		%2
	Account Domain:		%3

Changed Attributes:
	SAM Account Name:	%10
	Display Name:		%11
	User Principal Name:	%12
	Home Directory:		%13
	Home Drive:		%14
	Script Path:		%15
	Profile Path:		%16
	User Workstations:	%17
	Password Last Set:	%18
	Account Expires:		%19
	Primary Group ID:	%20
	AllowedToDelegateTo:	%21
	Old UAC Value:		%22
	New UAC Value:		%23
	User Account Control:	%24
	User Parameters:	%25
	SID History:		%26
	Logon Hours:		%27
	DNS Host Name:		%28
	Service Principal Names:	%29

Additional Information:
	Privileges:		%9
++++
  event:
    value: 4743
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A computer account was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Target Computer:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4744
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-disabled local group was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

New Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4745
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-disabled local group was changed.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Changed Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4746
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was added to a security-disabled local group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4747
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was removed from a security-disabled local group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4748
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-disabled local group was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4749
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-disabled global group was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4750
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-disabled global group was changed.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Changed Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4751
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was added to a security-disabled global group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4752
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was removed from a security-disabled global group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4753
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-disabled global group was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4754
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-enabled universal group was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4755
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-enabled universal group was changed.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Changed Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4756
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was added to a security-enabled universal group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Account Name:		%3
	Account Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4757
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was removed from a security-enabled universal group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4758
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-enabled universal group was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4759
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-disabled universal group was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4760
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-disabled universal group was changed.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Changed Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4761
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was added to a security-disabled universal group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4762
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was removed from a security-disabled universal group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4763
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security-disabled universal group was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Group Name:		%1
	Group Domain:		%2

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4764
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A group’s type was changed.

Subject:
	Security ID:		%5
	Account Name:		%6
	Account Domain:		%7
	Logon ID:		%8

Change Type:			%1

Group:
	Security ID:		%4
	Group Name:		%2
	Group Domain:		%3

Additional Information:
	Privileges:		%9
++++
  event:
    value: 4765
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: SID History was added to an account.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Target Account:
	Security ID:		%5
	Account Name:		%3
	Account Domain:		%4

Source Account:
	Security ID:		%2
	Account Name:		%1

Additional Information:
	Privileges:		%10
	SID List:			%11
++++
  event:
    value: 4766
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt to add SID History to an account failed.

Subject:
	Security ID:
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Target Account:
	Security ID:		%4
	Account Name:		%2
	Account Domain:		%3

Source Account
	Account Name:		%1

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4767
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A user account was unlocked.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Target Account:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2
++++
  event:
    value: 4768
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Kerberos authentication ticket (TGT) was requested.

Account Information:
	Account Name:		%1
	Supplied Realm Name:	%2
	User ID:			%3

Service Information:
	Service Name:		%4
	Service ID:		%5

Network Information:
	Client Address:		%10
	Client Port:		%11

Additional Information:
	Ticket Options:		%6
	Result Code:		%7
	Ticket Encryption Type:	%8
	Pre-Authentication Type:	%9

Certificate Information:
	Certificate Issuer Name:		%12
	Certificate Serial Number:	%13
	Certificate Thumbprint:		%14

++Certificate information is only provided if a certificate was used for pre-authentication.Pre-authentication types, ticket options, encryption types and result codes are defined in RFC 4120.++
  event:
    value: 4769
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Kerberos service ticket was requested.

Account Information:
	Account Name:		%1
	Account Domain:		%2
	Logon GUID:		%10

Service Information:
	Service Name:		%3
	Service ID:		%4

Network Information:
	Client Address:		%7
	Client Port:		%8

Additional Information:
	Ticket Options:		%5
	Ticket Encryption Type:	%6
	Failure Code:		%9
	Transited Services:	%11

++This event is generated every time access is requested to a resource such as a computer or a Windows service.  The service name indicates the resource to which access was requested.This event can be correlated with Windows logon events by comparing the Logon GUID fields in each event.  The logon event occurs on the machine that was accessed, which is often a different machine than the domain controller which issued the service ticket.Ticket options, encryption types, and failure codes are defined in RFC 4120.++
  event:
    value: 4770
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Kerberos service ticket was renewed.

Account Information:
	Account Name:		%1
	Account Domain:		%2

Service Information:
	Service Name:		%3
	Service ID:		%4

Network Information:
	Client Address:		%7
	Client Port:		%8

Additional Information:
	Ticket Options:		%5
	Ticket Encryption Type:	%6

++Ticket options and encryption types are defined in RFC 4120.++
  event:
    value: 4771
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Kerberos pre-authentication failed.

Account Information:
	Security ID:		%2
	Account Name:		%1

Service Information:
	Service Name:		%3

Network Information:
	Client Address:		%7
	Client Port:		%8

Additional Information:
	Ticket Options:		%4
	Failure Code:		%5
	Pre-Authentication Type:	%6

Certificate Information:
	Certificate Issuer Name:		%9
	Certificate Serial Number: 	%10
	Certificate Thumbprint:		%11

++Certificate information is only provided if a certificate was used for pre-authentication.Pre-authentication types, ticket options and failure codes are defined in RFC 4120.If the ticket was malformed or damaged during transit and could not be decrypted, then many fields in this event might not be present.++
  event:
    value: 4772
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Kerberos authentication ticket request failed.

Account Information:
	Account Name:		%1
	Supplied Realm Name:	%2

Service Information:
	Service Name:	%3

Network Information:
	Client Address:	%6
	Client Port:	%7

Additional Information:
	Ticket Options:	%4
	Failure Code:	%5

++Ticket options and failure codes are defined in RFC 4120.++
  event:
    value: 4773
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Kerberos service ticket request failed.

Account Information:
	Account Name:		%1
	Account Domain:		%2

Service Information:
	Service Name:	%3

Network Information:
	Client Address:	%6
	Client Port:	%7

Additional Information:
	Ticket Options:	%4
	Failure Code:	%5

++Ticket options and failure codes are defined in RFC 4120.++
  event:
    value: 4774
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An account was mapped for logon.

Authentication Package:	%1
Account UPN:	%2
Mapped Name:	%3
++++
  event:
    value: 4775
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An account could not be mapped for logon.

Authentication Package:		%1
Account Name:		%2
++++
  event:
    value: 4776
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The domain controller attempted to validate the credentials for an account.

Authentication Package:	%1
Logon Account:	%2
Source Workstation:	%3
Error Code:	%4
++++
  event:
    value: 4777
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The domain controller failed to validate the credentials for an account.

Authentication Package:	%1
Logon Account:	%2
Source Workstation:	%3
Error Code:	%4
++++
  event:
    value: 4778
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A session was reconnected to a Window Station.

Subject:
	Account Name:		%1
	Account Domain:		%2
	Logon ID:		%3

Session:
	Session Name:		%4

Additional Information:
	Client Name:		%5
	Client Address:		%6

++This event is generated when a user reconnects to an existing Terminal Services session, or when a user switches to an existing desktop using Fast User Switching.++
  event:
    value: 4779
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A session was disconnected from a Window Station.

Subject:
	Account Name:		%1
	Account Domain:		%2
	Logon ID:		%3

Session:
	Session Name:		%4

Additional Information:
	Client Name:		%5
	Client Address:		%6


++This event is generated when a user disconnects from an existing Terminal Services session, or when a user switches away from an existing desktop using Fast User Switching.++
  event:
    value: 4780
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The ACL was set on accounts which are members of administrators groups.


Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Target Account:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Additional Information:
	Privileges:		%8

++Every hour, the Windows domain controller that holds the primary domain controller (PDC) Flexible Single Master Operation (FSMO) role compares the ACL on all security principal accounts (users, groups, and machine accounts) present for its domain in Active Directory and that are in administrative groups against the ACL on the AdminSDHolder object.  If the ACL on the principal account differs from the ACL on the AdminSDHolder object, then the ACL on the principal account is reset to match the ACL on the AdminSDHolder object and this event is generated.++
  event:
    value: 4781
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The name of an account was changed:

Subject:
	Security ID:		%5
	Account Name:		%6
	Account Domain:		%7
	Logon ID:		%8

Target Account:
	Security ID:		%4
	Account Domain:		%3
	Old Account Name:	%1
	New Account Name:	%2

Additional Information:
	Privileges:		%9
++++
  event:
    value: 4782
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The password hash an account was accessed.

Subject:
	Security ID:		%3
	Account Name:		%4
	Account Domain:		%5
	Logon ID:		%6

Target Account:
	Account Name:		%1
	Account Domain:		%2
++++
  event:
    value: 4783
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A basic application group was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4784
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A basic application group was changed.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4785
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was added to a basic application group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4786
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A member was removed from a basic application group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Group Name:		%3
	Group Domain:		%4

Additional Information:
	Privileges:		%10
++++
  event:
    value: 4787
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A non-member was added to a basic application group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Account Name:		%3
	Account Domain:		%4

Additional Information:
	Privileges:		%10

++A non-member is an account that is explicitly excluded from membership in a basic application group.  Even if the account is specified as a member of the application group, either explicitly or through nested group membership, the account will not be treated as a group member if it is listed as a non-member.++
  event:
    value: 4788
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A non-member was removed from a basic application group.

Subject:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9

Member:
	Security ID:		%2
	Account Name:		%1

Group:
	Security ID:		%5
	Account Name:		%3
	Account Domain:		%4

Additional Information:
	Privileges:		%10

++A non-member is an account that is explicitly excluded from membership in a basic application group.  Even if the account is specified as a member of the application group, either explicitly or through nested group membership, the account will not be treated as a group member if it is listed as a non-member.++
  event:
    value: 4789
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A basic application group was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4790
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An LDAP query group was created.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4791
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A basic application group was changed.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Attributes:
	SAM Account Name:	%9
	SID History:		%10

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4792
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An LDAP query group was deleted.

Subject:
	Security ID:		%4
	Account Name:		%5
	Account Domain:		%6
	Logon ID:		%7

Group:
	Security ID:		%3
	Account Name:		%1
	Account Domain:		%2

Additional Information:
	Privileges:		%8
++++
  event:
    value: 4793
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Password Policy Checking API was called.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Additional Information:
	Caller Workstation:	%5
	Provided Account Name (unauthenticated):	%6
	Status Code:	%7
++++
  event:
    value: 4794
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt was made to set the Directory Services Restore Mode
administrator password.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Additional Information:
	Caller Workstation:	%5
	Status Code:	%6
++++
  event:
    value: 4800
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The workstation was locked.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4
	Session ID:	%5
++++
  event:
    value: 4801
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The workstation was unlocked.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4
	Session ID:	%5
++++
  event:
    value: 4802
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The screen saver was invoked.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4
	Session ID:	%5
++++
  event:
    value: 4803
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The screen saver was dismissed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4
	Session ID:	%5
++++
  event:
    value: 4816
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: RPC detected an integrity violation while decrypting an incoming message.

Peer Name:	%1
Protocol Sequence:	%2
Security Error:	%3
++++
  event:
    value: 4864
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A namespace collision was detected.

Target Type:	%1
Target Name:	%2
Forest Root:	%3
Top Level Name:	%4
DNS Name:	%5
NetBIOS Name:	%6
Security ID:		%7
New Flags:	%8
++++
  event:
    value: 4865
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A trusted forest information entry was added.

Subject:
	Security ID:		%10
	Account Name:		%11
	Account Domain:		%12
	Logon ID:		%13

Trust Information:
	Forest Root:	%1
	Forest Root SID:	%2
	Operation ID:	%3
	Entry Type:	%4
	Flags:	%5
	Top Level Name:	%6
	DNS Name:	%7
	NetBIOS Name:	%8
	Domain SID:	%9
++++
  event:
    value: 4866
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A trusted forest information entry was removed.

Subject:
	Security ID:		%10
	Account Name:		%11
	Account Domain:		%12
	Logon ID:		%13

Trust Information:
	Forest Root:	%1
	Forest Root SID:	%2
	Operation ID:	%3
	Entry Type:	%4
	Flags:	%5
	Top Level Name:	%6
	DNS Name:	%7
	NetBIOS Name:	%8
	Domain SID:	%9
++++
  event:
    value: 4867
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A trusted forest information entry was modified.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Trust Information:
	Forest Root:	%5
	Forest Root SID:	%6
	Operation ID:	%7
	Entry Type:	%8
	Flags:	%9
	Top Level Name:	%10
	DNS Name:	%11
	NetBIOS Name:	%12
	Domain SID:	%13
++++
  event:
    value: 4868
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The certificate manager denied a pending certificate request.
	
Request ID:	%1
++++
  event:
    value: 4869
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services received a resubmitted certificate request.
	
Request ID:	%1
++++
  event:
    value: 4870
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services revoked a certificate.
	
Serial Number:	%1
Reason:	%2
++++
  event:
    value: 4871
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services received a request to publish the certificate revocation list (CRL).
	
Next Update:	%1
Publish Base:	%2
Publish Delta:	%3
++++
  event:
    value: 4872
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services published the certificate revocation list (CRL).
	
Base CRL:	%1
CRL Number:	%2
Key Container:	%3
Next Publish:	%4
Publish URLs:	%5
++++
  event:
    value: 4873
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A certificate request extension changed.
	
Request ID:	%1
Name:	%2
Type:	%3
Flags:	%4
Data:	%5
++++
  event:
    value: 4874
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: One or more certificate request attributes changed.
	
Request ID:	%1
Attributes:	%2
++++
  event:
    value: 4875
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services received a request to shut down.
++++
  event:
    value: 4876
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services backup started.

Backup Type:	%1
++++
  event:
    value: 4877
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services backup completed.
++++
  event:
    value: 4878
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services restore started.
++++
  event:
    value: 4879
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services restore completed.
++++
  event:
    value: 4880
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services started.
	
Certificate Database Hash:	%1
Private Key Usage Count:	%2
CA Certificate Hash:	%3
CA Public Key Hash:	%4
++++
  event:
    value: 4881
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services stopped.
	
Certificate Database Hash:	%1
Private Key Usage Count:	%2
CA Certificate Hash:	%3
CA Public Key Hash:	%4
++++
  event:
    value: 4882
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The security permissions for Certificate Services changed.
	
%1
++++
  event:
    value: 4883
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services retrieved an archived key.
	
Request ID:	%1
++++
  event:
    value: 4884
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services imported a certificate into its database.
	
Certificate:	%1
Request ID:	%2
++++
  event:
    value: 4885
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The audit filter for Certificate Services changed.
	
Filter:	%1
++++
  event:
    value: 4886
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services received a certificate request.
	
Request ID:	%1
Requester:	%2
Attributes:	%3
++++
  event:
    value: 4887
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services approved a certificate request and issued a certificate.
	
Request ID:	%1
Requester:	%2
Attributes:	%3
Disposition:	%4
SKI:		%5
Subject:	%6
++++
  event:
    value: 4888
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services denied a certificate request.
	
Request ID:	%1
Requester:	%2
Attributes:	%3
Disposition:	%4
SKI:		%5
Subject:	%6
++++
  event:
    value: 4889
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services set the status of a certificate request to pending.
	
Request ID:	%1
Requester:	%2
Attributes:	%3
Disposition:	%4
SKI:		%5
Subject:	%6
++++
  event:
    value: 4890
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The certificate manager settings for Certificate Services changed.
	
Enable:	%1

%2
++++
  event:
    value: 4891
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A configuration entry changed in Certificate Services.
	
Node:	%1
Entry:	%2
Value:	%3
++++
  event:
    value: 4892
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A property of Certificate Services changed.
	
Property:	%1
Index:	%2
Type:	%3
Value:	%4
++++
  event:
    value: 4893
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services archived a key.
	
Request ID:	%1
Requester:	%2
KRA Hashes:	%3
++++
  event:
    value: 4894
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services imported and archived a key.
	
Request ID:	%1
++++
  event:
    value: 4895
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services published the CA certificate to Active Directory Domain Services.
	
Certificate Hash:	%1
Valid From:	%2
Valid To:		%3
++++
  event:
    value: 4896
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: One or more rows have been deleted from the certificate database.
	
Table ID:	%1
Filter:	%2
Rows Deleted:	%3
++++
  event:
    value: 4897
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Role separation enabled:	%1
++++
  event:
    value: 4898
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services loaded a template.

%1 v%2 (Schema V%3)
%4
%5

Template Information:
	Template Content:		%7
	Security Descriptor:		%8

Additional Information:
	Domain Controller:	%6
++++
  event:
    value: 4899
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Certificate Services template was updated.

%1 v%2 (Schema V%3)
%4
%5

Template Change Information:
	Old Template Content:	%8
	New Template Content:		%7

Additional Information:
	Domain Controller:	%6
++++
  event:
    value: 4900
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Certificate Services template security was updated.

%1 v%2 (Schema V%3)
%4
%5

Template Change Information:
	Old Template Content:		%9
	New Template Content:	%7
	Old Security Descriptor:		%10
	New Security Descriptor:		%8

Additional Information:
	Domain Controller:	%6
++++
  event:
    value: 4902
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Per-user audit policy table was created.

Number of Elements:	%1
Policy ID:	%2
++++
  event:
    value: 4904
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt was made to register a security event source.

Subject :
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Process:
	Process ID:	%7
	Process Name:	%8

Event Source:
	Source Name:	%5
	Event Source ID:	%6
++++
  event:
    value: 4905
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt was made to unregister a security event source.

Subject
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Process:
	Process ID:	%7
	Process Name:	%8

Event Source:
	Source Name:	%5
	Event Source ID:	%6
++++
  event:
    value: 4906
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The CrashOnAuditFail value has changed.

New Value of CrashOnAuditFail:	%1
++++
  event:
    value: 4907
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Auditing settings on object were changed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Object Server:	%5
	Object Type:	%6
	Object Name:	%7
	Handle ID:	%8

Process Information:
	Process ID:	%11
	Process Name:	%12

Auditing Settings:
	Original Security Descriptor:	%9
	New Security Descriptor:		%10
++++
  event:
    value: 4908
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Special Groups Logon table modified.

Special Groups:	%1

++This event is generated when the list of special groups is updated in the registry or through security policy. The updated list of special groups is indicated in the event.++
  event:
    value: 4909
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The local policy settings for the TBS were changed.

Old Blocked Ordinals:	%1
New Blocked Ordinals:	%2
++++
  event:
    value: 4910
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The group policy settings for the TBS were changed.

Group Policy Setting:		Ignore Default Settings
	Old Value:		%1
	New Value:		%2

Group Policy Setting:		Ignore Local Settings
	Old Value:		%3
	New Value:		%4

Old Blocked Ordinals:	%5
New Blocked Ordinals:	%6
++++
  event:
    value: 4912
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Per User Audit Policy was changed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Policy For Account:
	Security ID:		%5

Policy Change Details:
	Category:	%6
	Subcategory:	%7
	Subcategory GUID:	%8
	Changes:	%9
++++
  event:
    value: 4928
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An Active Directory replica source naming context was established.

Destination DRA:	%1
Source DRA:	%2
Source Address:	%3
Naming Context:	%4
Options:		%5
Status Code:	%6
++++
  event:
    value: 4929
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An Active Directory replica source naming context was removed.

Destination DRA:	%1
Source DRA:	%2
Source Address:	%3
Naming Context:	%4
Options:		%5
Status Code:	%6
++++
  event:
    value: 4930
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An Active Directory replica source naming context was modified.

Destination DRA:	%1
Source DRA:	%2
Source Address:	%3
Naming Context:	%4
Options:		%5
Status Code:	%6
++++
  event:
    value: 4931
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An Active Directory replica destination naming context was modified.

Destination DRA:	%1
Source DRA:	%2
Destination Address:	%3
Naming Context:	%4
Options:		%5
Status Code:	%6
++++
  event:
    value: 4932
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Synchronization of a replica of an Active Directory naming context has begun.

Destination DRA:	%1
Source DRA:	%2
Naming Context:	%3
Options:		%4
Session ID:	%5
Start USN:	%6
++++
  event:
    value: 4933
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Synchronization of a replica of an Active Directory naming context has ended.

Destination DRA:	%1
Source DRA:	%2
Naming Context:	%3
Options:		%4
Session ID:	%5
End USN:	%6
Status Code:	%7
++++
  event:
    value: 4934
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Attributes of an Active Directory object were replicated.

Session ID:	%1
Object:		%2
Attribute:	%3
Type of change:	%4
New Value:	%5
USN:		%6
Status Code:	%7
++++
  event:
    value: 4935
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Replication failure begins.

Replication Event:	%1
Audit Status Code:	%2
++++
  event:
    value: 4936
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Replication failure ends.

Replication Event:	%1
Audit Status Code:	%2
Replication Status Code:	%3
++++
  event:
    value: 4937
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A lingering object was removed from a replica.

Destination DRA:	%1
Source DRA:	%2
Object:	%3
Options:	%4
Status Code:	%5
++++
  event:
    value: 4944
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The following policy was active when the Windows Firewall started.

Group Policy Applied:	%1
Profile Used:	%2
Operational mode:	%3
Allow Remote Administration:	%4
Allow Unicast Responses to Multicast/Broadcast Traffic:	%5
Security Logging:
	Log Dropped Packets:	%6
	Log Successful Connections:	%7
++++
  event:
    value: 4945
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A rule was listed when the Windows Firewall started.
	
Profile used:	%1

Rule:
	Rule ID:	%2
	Rule Name:	%3
++++
  event:
    value: 4946
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to Windows Firewall exception list. A rule was added.
	
Profile Changed:	%1

Added Rule:
	Rule ID:	%2
	Rule Name:	%3
++++
  event:
    value: 4947
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to Windows Firewall exception list. A rule was modified.
	
Profile Changed:	%1

Modified Rule:
	Rule ID:	%2
	Rule Name:	%3
++++
  event:
    value: 4948
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to Windows Firewall exception list. A rule was deleted.
	
Profile Changed:	%1

Deleted Rule:
	Rule ID:	%2
	Rule Name:	%3
++++
  event:
    value: 4949
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Windows Firewall settings were restored to the default values.
++++
  event:
    value: 4950
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Windows Firewall setting has changed.
	
Profile That Was Changed:	%1

New Setting:
	Type:	%2
	Value:	%3
++++
  event:
    value: 4951
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A rule has been ignored because its major version number was not recognized by Windows Firewall.
	
Profile:	%1

Ignored Rule:
	ID:	%2
	Name:	%3
++++
  event:
    value: 4952
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Parts of a rule have been ignored because its minor version number was not recognized by Windows Firewall. The other parts of the rule will be enforced.
	
Profile:	%1

Partially Ignored Rule:
	ID:	%2
	Name:	%3
++++
  event:
    value: 4953
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A rule has been ignored by Windows Firewall because it could not parse the rule.
	
Profile:	%1

Reason for Rejection:	%2

Rule:
	ID:	%3
	Name:	%4
++++
  event:
    value: 4954
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Windows Firewall Group Policy settings has changed. The new settings have been applied.
++++
  event:
    value: 4956
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Windows Firewall has changed the active profile.

New Active Profile:	%1
++++
  event:
    value: 4957
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Windows Firewall did not apply the following rule:

Rule Information:
	ID:	%1
	Name:	%2

Error Information:
	Reason:	%3 resolved to an empty set.
++++
  event:
    value: 4958
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Windows Firewall did not apply the following rule because the rule referred to items not configured on this computer:

Rule Information:
	ID:	%1
	Name:	%2

Error Information:
	Error:	%3
	Reason:	%4
++++
  event:
    value: 4960
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec dropped an inbound packet that failed an integrity check. If this problem persists, it could indicate a network issue or that packets are being modified in transit to this computer. Verify that the packets sent from the remote computer are the same as those received by this computer. This error might also indicate interoperability problems with other IPsec implementations.

Remote Network Address:	%1
Inbound SA SPI:		%2
++++
  event:
    value: 4961
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec dropped an inbound packet that failed a replay check. If this problem persists, it could indicate a replay attack against this computer.

Remote Network Address:	%1
Inbound SA SPI:		%2
++++
  event:
    value: 4962
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec dropped an inbound packet that failed a replay check. The inbound packet had too low a sequence number to ensure it was not a replay.

Remote Network Address:	%1
Inbound SA SPI:		%2
++++
  event:
    value: 4963
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec dropped an inbound clear text packet that should have been secured. This is usually due to the remote computer changing its IPsec policy without informing this computer. This could also be a spoofing attack attempt.

Remote Network Address:	%1
Inbound SA SPI:		%2
++++
  event:
    value: 4964
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Special groups have been assigned to a new logon.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4
	Logon GUID:	%5

New Logon:
	Security ID:		%6
	Account Name:		%7
	Account Domain:		%8
	Logon ID:		%9
	Logon GUID:	%10
	Special Groups Assigned:	%11
++++
  event:
    value: 4965
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec received a packet from a remote computer with an incorrect Security Parameter Index (SPI). This is usually caused by malfunctioning hardware that is corrupting packets. If these errors persist, verify that the packets sent from the remote computer are the same as those received by this computer. This error may also indicate interoperability problems with other IPsec implementations. In that case, if connectivity is not impeded, then these events can be ignored.

Remote Network Address:	%1
Inbound SA SPI:		%2
++++
  event:
    value: 4976
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: During Main Mode negotiation, IPsec received an invalid negotiation packet. If this problem persists, it could indicate a network issue or an attempt to modify or replay this negotiation.

Local Network Address:	%1
Remote Network Address:	%2
Keying Module Name:	%3
++++
  event:
    value: 4977
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: During Quick Mode negotiation, IPsec received an invalid negotiation packet. If this problem persists, it could indicate a network issue or an attempt to modify or replay this negotiation.

Local Network Address:	%1
Remote Network Address:	%2
Keying Module Name:	%3
++++
  event:
    value: 4978
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: During Extended Mode negotiation, IPsec received an invalid negotiation packet. If this problem persists, it could indicate a network issue or an attempt to modify or replay this negotiation.

Local Network Address:	%1
Remote Network Address:	%2
Keying Module Name:	%3
++++
  event:
    value: 4979
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Main Mode and Extended Mode security associations were established.

Main Mode Local Endpoint:
	Principal Name:		%1
	Network Address:	%3
	Keying Module Port:	%4

Main Mode Remote Endpoint:
	Principal Name:	%2
	Network Address:	%5
	Keying Module Port:	%6

Main Mode Cryptographic Information:
	Cipher Algorithm:	%8
	Integrity Algorithm:	%9
	Diffie-Hellman Group:	%10

Main Mode Security Association:
	Lifetime (minutes):	%11
	Quick Mode Limit:	%12
	Main Mode SA ID:	%16
	
Main Mode Additional Information:
	Keying Module Name:	AuthIP
	Authentication Method:	%7
	Role:			%13
	Impersonation State:	%14
	Main Mode Filter ID:	%15

Extended Mode Information:
	Local Principal Name:	%17
	Remote Principal Name:	%18
	Authentication Method:	%19
	Impersonation State:	%20
	Quick Mode Filter ID:	%21
++++
  event:
    value: 4980
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Main Mode and Extended Mode security associations were established.

Main Mode Local Endpoint:
	Principal Name:		%1
	Network Address:	%3
	Keying Module Port:	%4

Main Mode Remote Endpoint:
	Principal Name:	%2
	Network Address:	%5
	Keying Module Port:	%6

Main Mode Cryptographic Information:
	Cipher Algorithm:	%8
	Integrity Algorithm:	%9
	Diffie-Hellman Group:	%10

Main Mode Security Association:
	Lifetime (minutes):	%11
	Quick Mode Limit:	%12
	Main Mode SA ID:	%16
	
Main Mode Additional Information:
	Keying Module Name:	AuthIP
	Authentication Method:	%7
	Role:			%13
	Impersonation State:	%14
	Main Mode Filter ID:	%15

Extended Mode Local Endpoint:
	Principal Name:	%17
	Certificate SHA Thumbprint:	%18
	Certificate Issuing CA:	%19
	Certificate Root CA:	%20

Extended Mode Remote Endpoint:
	Principal Name:	%21
	Certificate SHA Thumbprint:	%22
	Certificate Issuing CA:	%23
	Certificate Root CA:	%24

Extended Mode Additional Information:
	Authentication Method:	SSL
	Impersonation State:	%25
	Quick Mode Filter ID:	%26
++++
  event:
    value: 4981
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Main Mode and Extended Mode security associations were established.

Local Endpoint:
	Principal Name:		%1
	Network Address:	%9
	Keying Module Port:	%10

Local Certificate:
	SHA Thumbprint:	%2
	Issuing CA:		%3
	Root CA:		%4

Remote Endpoint:
	Principal Name:		%5
	Network Address:	%11
	Keying Module Port:	%12

Remote Certificate:
	SHA Thumbprint:	%6
	Issuing CA:		%7
	Root CA:		%8

Cryptographic Information:
	Cipher Algorithm:	%13
	Integrity Algorithm:	%14
	Diffie-Hellman Group:	%15

Security Association Information:
	Lifetime (minutes):	%16
	Quick Mode Limit:	%17
	Main Mode SA ID:	%21

Additional Information:
	Keying Module Name:	AuthIP
	Authentication Method:	SSL
	Role:			%18
	Impersonation State:	%19
	Main Mode Filter ID:	%20
	
Extended Mode Information:
	Local Principal Name:	%22
	Remote Principal Name:	%23
	Authentication Method:	%24
	Impersonation State:	%25
	Quick Mode Filter ID:	%26
++++
  event:
    value: 4982
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Main Mode and Extended Mode security associations were established.

Local Endpoint:
	Principal Name:		%1
	Network Address:	
	Keying Module Port:	%9

Local Certificate:
	SHA Thumbprint:	%2
	Issuing CA:		%3
	Root CA:		%4

Remote Endpoint:
	Principal Name:		%5
	Network Address:	%11
	Keying Module Port:	%12

Remote Certificate:
	SHA Thumbprint:	%6
	Issuing CA:		%7
	Root CA:		%8

Cryptographic Information:
	Cipher Algorithm:	%12
	Integrity Algorithm:	%13
	Diffie-Hellman Group:	%14

Security Association Information:
	Lifetime (minutes):	%15
	Quick Mode Limit:	%16
	Main Mode SA ID:	%20

Additional Information:
	Keying Module Name:	AuthIP
	Authentication Method:	SSL
	Role:			%17
	Impersonation State:	%18
	Main Mode Filter ID:	%19
	
Extended Mode Local Endpoint:
	Principal Name:		%21
	Certificate SHA Thumbprint:	%22
	Certificate Issuing CA:	%23
	Certificate Root CA:	%24

Extended Mode Remote Endpoint:
	Principal Name:		%25
	Certificate SHA Thumbprint:	%26
	Certificate Issuing CA:	%27
	Certificate Root CA:	%28
Extended Mode Additional Information:
	Authentication Method:	SSL
	Impersonation State:	%29
	Quick Mode Filter ID:	%30
++++
  event:
    value: 4983
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Extended Mode negotiation failed. The corresponding Main Mode security association has been deleted.


Local Endpoint:
	Principal Name:		%1
	Network Address:	%9
	Keying Module Port:	%10

Local Certificate:
	SHA Thumbprint:	%2
	Issuing CA:		%3
	Root CA:		%4

Remote Endpoint:
	Principal Name:		%5
	Network Address:	%11
	Keying Module Port:	%12

Remote Certificate:
	SHA Thumbprint:	%6
	Issuing CA:		%7
	Root CA:		%8

Additional Information:
	Keying Module Name:	AuthIP
	Authentication Method:	SSL
	Role:			%16
	Impersonation State:	%17
	Quick Mode Filter ID:	%18

Failure Information:
	Failure Point:		%13
	Failure Reason:		%14
	State:			%15
++++
  event:
    value: 4984
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Extended Mode negotiation failed. The corresponding Main Mode security association has been deleted.

Local Endpoint:
	Principal Name:		%1
	Network Address:	%3
	Keying Module Port:	%4

Remote Endpoint:
	Principal Name:		%2
	Network Address:	%5
	Keying Module Port:	%6

Additional Information:
	Keying Module Name:	AuthIP
	Authentication Method:	%9
	Role:			%11
	Impersonation State:	%12
	Quick Mode Filter ID:	%13

Failure Information:
	Failure Point:		%7
	Failure Reason:		%8
	State:			%10
++++
  event:
    value: 4985
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The state of a transaction has changed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Transaction Information:
	RM Transaction ID:	%5
	New State:		%6
	Resource Manager:	%7

Process Information:
	Process ID:		%8
	Process Name:		%9
++++
  event:
    value: 5024
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Service has started successfully.
++++
  event:
    value: 5025
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Service has been stopped.
++++
  event:
    value: 5027
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Service was unable to retrieve the security policy from the local storage. The service will continue enforcing the current policy.

Error Code:	%1
++++
  event:
    value: 5028
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Service was unable to parse the new security policy. The service will continue with currently enforced policy.

Error Code:	%1
++++
  event:
    value: 5029
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Service failed to initialize the driver. The service will continue to enforce the current policy.

Error Code:	%1
++++
  event:
    value: 5030
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Service failed to start.

Error Code:	%1
++++
  event:
    value: 5031
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Service blocked an application from accepting incoming connections on the network.

Profiles:		%1
Application:		%2
++++
  event:
    value: 5032
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Windows Firewall was unable to notify the user that it blocked an application from accepting incoming connections on the network.

Error Code:	%1
++++
  event:
    value: 5033
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Driver has started successfully.
++++
  event:
    value: 5034
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Driver has been stopped.
++++
  event:
    value: 5035
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Driver failed to start.

Error Code:	%1
++++
  event:
    value: 5037
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Firewall Driver detected critical runtime error. Terminating.

Error Code:	%1
++++
  event:
    value: 5038
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Code integrity determined that the image hash of a file is not valid.  The file could be corrupt due to unauthorized modification or the invalid hash could indicate a potential disk device error.

File Name:	%1	
++++
  event:
    value: 5039
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A registry key was virtualized.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	Key Name:		%5
	Virtual Key Name:		%6

Process Information:
	Process ID:		%7
	Process Name:		%8
++++
  event:
    value: 5040
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to IPsec settings. An Authentication Set was added.
	
Profile Changed:		%1

Added Authentication Set:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5041
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to IPsec settings. An Authentication Set was modified.
	
Profile Changed:		%1

Modified Authentication Set:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5042
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to IPsec settings. An Authentication Set was deleted.
	
Profile Changed:		%1

Deleted Authentication Set:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5043
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to IPsec settings. A Connection Security Rule was added.
	
Profile Changed:		%1

Added Connection Security Rule:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5044
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to IPsec settings. A Connection Security Rule was modified.
	
Profile Changed:	%1

Modified Connection Security Rule:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5045
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to IPsec settings. A Connection Security Rule was deleted.
	
Profile Changed:	%1

Deleted Connection Security Rule:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5046
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to IPsec settings. A Crypto Set was added.
	
Profile Changed:	%1

Added Crypto Set:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5047
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to IPsec settings. A Crypto Set was modified.
	
Profile Changed:	%1

Modified Crypto Set:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5048
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A change has been made to IPsec settings. A Crypto Set was deleted.
	
Profile Changed:	%1

Deleted Crypto Set:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5049
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Security Association was deleted.
	
Profile Changed:	%1

Deleted SA:
	ID:			%2
	Name:			%3
++++
  event:
    value: 5050
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An attempt to programmatically disable the Windows Firewall using a call to INetFwProfile.FirewallEnabled(FALSE) interface was rejected because this API is not supported on Windows Vista. This has most likely occurred due to a program which is incompatible with Windows Vista. Please contact the program's manufacturer to make sure you have a Windows Vista compatible program version.

Error Code:		E_NOTIMPL
Caller Process Name:		%1
Process Id:		%2
Publisher:		%3
++++
  event:
    value: 5051
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A file was virtualized.

Subject:
	Security ID:			%1
	Account Name:			%2
	Account Domain:		%3
	Logon ID:			%4

Object:
	File Name:			%5
	Virtual File Name:	%6

Process Information:
	Process ID:			%7
	Process Name:			%8
++++
  event:
    value: 5056
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic self test was performed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Module:		%5

Return Code:	%6
++++
  event:
    value: 5057
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic primitive operation failed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Cryptographic Parameters:
	Provider Name:		%5
	Algorithm Name:	%6

Failure Information:
	Reason:			%7
	Return Code:		%8
++++
  event:
    value: 5058
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Key file operation.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Cryptographic Parameters:
	Provider Name:	%5
	Algorithm Name:	%6
	Key Name:	%7
	Key Type:	%8

Key File Operation Information:
	File Path:	%9
	Operation:	%10
	Return Code:	%11
++++
  event:
    value: 5059
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Key migration operation.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Cryptographic Parameters:
	Provider Name:	%5
	Algorithm Name:	%6
	Key Name:	%7
	Key Type:	%8

Additional Information:
	Operation:	%9
	Return Code:	%10
++++
  event:
    value: 5060
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Verification operation failed.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Cryptographic Parameters:
	Provider Name:	%5
	Algorithm Name:	%6
	Key Name:	%7
	Key Type:	%8

Failure Information:
	Reason:	%9
	Return Code:	%10
++++
  event:
    value: 5061
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Cryptographic operation.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Cryptographic Parameters:
	Provider Name:	%5
	Algorithm Name:	%6
	Key Name:	%7
	Key Type:	%8

Cryptographic Operation:
	Operation:	%9
	Return Code:	%10
++++
  event:
    value: 5062
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A kernel-mode cryptographic self test was performed.

Module:	%1

Return Code:	%2
++++
  event:
    value: 5063
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic provider operation was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Cryptographic Provider:
	Name:	%5
	Module:	%6

Operation:	%7

Return Code:	%8
++++
  event:
    value: 5064
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic context operation was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Configuration Parameters:
	Scope:	%5
	Context:	%6

Operation:	%7

Return Code:	%8
++++
  event:
    value: 5065
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic context modification was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

%Configuration Parameters:
	Scope:	%5
	Context:	%6

Change Information:
	Old Value:	%7
	New Value:	%8

Return Code:	%9
++++
  event:
    value: 5066
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic function operation was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Configuration Parameters:
	Scope:	%5
	Context:	%6
	Interface:	%7
	Function:	%8
	Position:	%9

Operation:	%10

Return Code:	%11
++++
  event:
    value: 5067
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic function modification was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Configuration Parameters:
	Scope:	%5
	Context:	%6
	Interface:	%7
	Function:	%8

Change Information:
	Old Value:	%9
	New Value:	%10

Return Code:	%11
++++
  event:
    value: 5068
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic function provider operation was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Configuration Parameters:
	Scope:	%5
	Context:	%6
	Interface:	%7
	Function:	%8
	Provider:	%9
	Position:	%10

Operation:	%11

Return Code:	%12
++++
  event:
    value: 5069
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic function property operation was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Configuration Parameters:
	Scope:	%5
	Context:	%6
	Interface:	%7
	Function:	%8
	Property:	%9

Operation:	%10

Value:	%11

Return Code:	%12
++++
  event:
    value: 5070
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A cryptographic function property modification was attempted.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Configuration Parameters:
	Scope:	%5
	Context:	%6
	Interface:	%7
	Function:	%8
	Property:	%9

Change Information:
	Old Value:	%10
	New Value:	%11

Return Code:	%12
++++
  event:
    value: 5120
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: OCSP Responder Service Started.
++++
  event:
    value: 5121
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: OCSP Responder Service Stopped.
++++
  event:
    value: 5122
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Configuration entry changed in the OCSP Responder Service.

CA Configuration ID:		%1
New Value:		%2
++++
  event:
    value: 5123
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A configuration entry changed in the OCSP Responder Service.

Property Name:		%1
New Value:		%2
++++
  event:
    value: 5124
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A security setting was updated on OCSP Responder Service.

New Value:	%1
++++
  event:
    value: 5125
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A request was submitted to OCSP Responder Service.
++++
  event:
    value: 5126
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Signing Certificate was automatically updated by the OCSP Responder Service.

CA Configuration ID:		%1
New Signing Certificate Hash:		%2
++++
  event:
    value: 5127
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The OCSP Revocation Provider successfully updated the revocation information.

CA Configuration ID:		%1
Base CRL Number:		%2
Base CRL This Update:		%3
Base CRL Hash:		%4
Delta CRL Number:		%5
Delta CRL Indicator:		%6
Delta CRL This Update:		%7
Delta CRL Hash:		%8
++++
  event:
    value: 5136
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A directory service object was modified.
	
Subject:
	Security ID:		%3
	Account Name:		%4
	Account Domain:		%5
	Logon ID:		%6

Directory Service:
	Name:	%7
	Type:	%8
	
Object:
	DN:	%9
	GUID:	%10
	Class:	%11
	
Attribute:
	LDAP Display Name:	%12
	Syntax (OID):	%13
	Value:	%14
	
Operation:
	Type:	%15
	Correlation ID:	%1
	Application Correlation ID:	%2
++++
  event:
    value: 5137
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A directory service object was created.
	
Subject:
	Security ID:		%3
	Account Name:		%4
	Account Domain:		%5
	Logon ID:		%6
	
Directory Service:
	Name:	%7
	Type:	%8
	
Object:
	DN:	%9
	GUID:	%10
	Class:	%11
	
Operation:
	Correlation ID:	%1
	Application Correlation ID:	%2
++++
  event:
    value: 5138
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A directory service object was undeleted.
	
Subject:
	Security ID:		%3
	Account Name:		%4
	Account Domain:		%5
	Logon ID:		%6
	
Directory Service:
	Name:	%7
	Type:	%8
	
Object:
	Old DN:	%9
	New DN:	%10
	GUID:	%11
	Class:	%12
	
Operation:
	Correlation ID:	%1
	Application Correlation ID:	%2
++++
  event:
    value: 5139
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A directory service object was moved.
	
Subject:
	Security ID:		%3
	Account Name:		%4
	Account Domain:		%5
	Logon ID:		%6
	
Directory Service:
	Name:		%7
	Type:		%8
	
Object:
	Old DN:		%9
	New DN:	%10
	GUID:		%11
	Class:		%12
	
Operation:
	Correlation ID:			%1
	Application Correlation ID:	%2
++++
  event:
    value: 5140
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A network share object was accessed.
	
Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Network Information:	
	Source Address:		%5
	Source Port:		%6
	
Share Name:			%7
++++
  event:
    value: 5141
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A directory service object was deleted.
	
Subject:
	Security ID:		%3
	Account Name:		%4
	Account Domain:		%5
	Logon ID:		%6
	
Directory Service:
	Name:	%7
	Type:	%8
	
Object:
	DN:	%9
	GUID:	%10
	Class:	%11
	
Operation:
	Tree Delete:	%12
	Correlation ID:	%1
	Application Correlation ID:	%2
++++
  event:
    value: 5152
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Filtering Platform blocked a packet.

Application Information:
	Process ID:		%1
	Application Name:	%2

Network Information:
	Direction:		%3
	Source Address:		%4
	Source Port:		%5
	Destination Address:	%6
	Destination Port:		%7
	Protocol:		%8

Filter Information:
	Filter Run-Time ID:	%9
	Layer Name:		%10
	Layer Run-Time ID:	%11
++++
  event:
    value: 5153
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A more restrictive Windows Filtering Platform filter has blocked a packet.

Application Information:
	Process ID:		%1
	Application Name:	%2

Network Information:
	Direction:		%3
	Source Address:		%4
	Source Port:		%5
	Destination Address:	%6
	Destination Port:		%7
	Protocol:		%8

Filter Information:
	Filter Run-Time ID:	%9
	Layer Name:		%10
	Layer Run-Time ID:	%11
++++
  event:
    value: 5154
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Filtering Platform has permitted an application or service to listen on a port for incoming connections.

Application Information:
	Process ID:		%1
	Application Name:	%2

Network Information:
	Source Address:		%3
	Source Port:		%4
	Protocol:		%5

Filter Information:
	Filter Run-Time ID:	%6
	Layer Name:		%7
	Layer Run-Time ID:	%8
++++
  event:
    value: 5155
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Filtering Platform has blocked an application or service from listening on a port for incoming connections.

Application Information:
	Process ID:		%1
	Application Name:	%2

Network Information:
	Source Address:		%3
	Source Port:		%4
	Protocol:		%5

Filter Information:
	Filter Run-Time ID:	%6
	Layer Name:		%7
	Layer Run-Time ID:	%8
++++
  event:
    value: 5156
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Filtering Platform has allowed a connection.

Application Information:
	Process ID:		%1
	Application Name:	%2

Network Information:
	Direction:		%3
	Source Address:		%4
	Source Port:		%5
	Destination Address:	%6
	Destination Port:		%7
	Protocol:		%8

Filter Information:
	Filter Run-Time ID:	%9
	Layer Name:		%10
	Layer Run-Time ID:	%11
++++
  event:
    value: 5157
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Filtering Platform has blocked a connection.

Application Information:
	Process ID:		%1
	Application Name:	%2

Network Information:
	Direction:		%3
	Source Address:		%4
	Source Port:		%5
	Destination Address:	%6
	Destination Port:		%7
	Protocol:		%8

Filter Information:
	Filter Run-Time ID:	%9
	Layer Name:		%10
	Layer Run-Time ID:	%11
++++
  event:
    value: 5158
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Filtering Platform has permitted a bind to a local port.

Application Information:
	Process ID:		%1
	Application Name:	%2

Network Information:
	Source Address:		%3
	Source Port:		%4
	Protocol:		%5

Filter Information:
	Filter Run-Time ID:	%6
	Layer Name:		%7
	Layer Run-Time ID:	%8
++++
  event:
    value: 5159
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The Windows Filtering Platform has blocked a bind to a local port.

Application Information:
	Process ID:		%1
	Application Name:	%2

Network Information:
	Source Address:		%3
	Source Port:		%4
	Protocol:		%5

Filter Information:
	Filter Run-Time ID:	%6
	Layer Name:		%7
	Layer Run-Time ID:	%8
++++
  event:
    value: 5376
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Credential Manager credentials were backed up.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

++This event occurs when a user backs up their own Credential Manager credentials. A user (even an Administrator) cannot back up the credentials of an account other than his own.++
  event:
    value: 5377
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Credential Manager credentials were restored from a backup.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

++This event occurs when a user restores his Credential Manager credentials from a backup. A user (even an Administrator) cannot restore the credentials of an account other than his own.++
  event:
    value: 5378
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The requested credentials delegation was disallowed by policy.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Credential Delegation Information:
	Security Package:	%5
	User's UPN:	%6
	Target Server:	%7
	Credential Type:	%8
++++
  event:
    value: 5440
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The following callout was present when the Windows Filtering Platform Base Filtering Engine started.

Provider Information:	
	ID:		%1
	Name:		%2

Callout Information:
	ID:		%3
	Name:		%4
	Type:		%5
	Run-Time ID:	%6

Layer Information:
	ID:		%7
	Name:		%8
	Run-Time ID:	%9
++++
  event:
    value: 5441
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The following filter was present when the Windows Filtering Platform Base Filtering Engine started.

Provider Information:	
	ID:		%1
	Name:		%2

Filter Information:
	ID:		%3
	Name:		%4
	Type:		%5
	Run-Time ID:	%6

Layer Information:
	ID:		%7
	Name:		%8
	Run-Time ID:	%9
	Weight:		%10
	
Additional Information:
	Conditions:	%11
	Filter Action:	%12
	Callout ID:	%13
	Callout Name:	%14
++++
  event:
    value: 5442
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The following provider was present when the Windows Filtering Platform Base Filtering Engine started.
	
Provider ID:	%1
Provider Name:	%2
Provider Type:	%3
++++
  event:
    value: 5443
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The following provider context was present when the Windows Filtering Platform Base Filtering Engine started.
	
Provider ID:	%1
Provider Name:	%2
Provider Context ID:	%3
Provider Context Name:	%4
Provider Context Type:	%5
++++
  event:
    value: 5444
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: The following sub-layer was present when the Windows Filtering Platform Base Filtering Engine started.
	
Provider ID:	%1
Provider Name:	%2
Sub-layer ID:	%3
Sub-layer Name:	%4
Sub-layer Type:	%5
Weight:		%6
++++
  event:
    value: 5446
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Windows Filtering Platform callout has been changed.
	
Subject:
	Security ID:		%2
	Account Name:		%3

Process Information:
	Process ID:	%1

Provider Information:
	ID:		%4
	Name:		%5

Change Information:
	Change Type:	%6

Callout Information:
	ID:		%7
	Name:		%8
	Type:		%9
	Run-Time ID:	%10

Layer Information:
	ID:		%11
	Name:		%12
	Run-Time ID:	%13
++++
  event:
    value: 5447
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Windows Filtering Platform filter has been changed.
	
Subject:
	Security ID:		%2
	Account Name:		%3

Process Information:
	Process ID:	%1

Provider Information:
	ID:		%4
	Name:		%5

Change Information:
	Change Type:	%6

Filter Information:
	ID:		%7
	Name:		%8
	Type:		%9
	Run-Time ID:	%10

Layer Information:
	ID:		%11
	Name:		%12
	Run-Time ID:	%13

Callout Information:
	ID:		%17
	Name:		%18

Additional Information:
	Weight:	%14	
	Conditions:	%15
	Filter Action:	%16
++++
  event:
    value: 5448
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Windows Filtering Platform provider has been changed.
	
Subject:
	Security ID:		%2
	Account Name:		%3

Process Information:
	Process ID:	%1

Change Information:
	Change Type:	%4

Provider Information:
	ID:		%5
	Name:		%6
	Type:		%7
++++
  event:
    value: 5449
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Windows Filtering Platform provider context has been changed.
	
Subject:
	Security ID:		%2
	Account Name:		%3

Process Information:
	Process ID:	%1

Provider Information:
	Provider ID:	%4
	Provider Name:	%5

Change Information:
	Change Type:	%6

Provider Context:
	ID:	%7
	Name:	%8
	Type:	%9
++++
  event:
    value: 5450
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Windows Filtering Platform sub-layer has been changed.
	
Subject:
	Security ID:		%2
	Account Name:		%3

Process Information:
	Process ID:	%1

Provider Information:
	Provider ID:	%4
	Provider Name:	%5

Change Information:
	Change Type:	%6

Sub-layer Information:
	Sub-layer ID:	%7
	Sub-layer Name:	%8
	Sub-layer Type:	%9

Additional Information:
	Weight:	%10
++++
  event:
    value: 5451
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Quick Mode security association was established.
	
Local Endpoint:
	Network Address:	%1
	Network Address mask:	%2
	Port:			%3
	Tunnel Endpoint:		%4

Remote Endpoint:
	Network Address:	%5
	Network Address Mask:	%6
	Port:			%7
	Private Address:		%8
	Tunnel Endpoint:		%9

	Protocol:		%10
	Keying Module Name:	%11

Cryptographic Information:
	Integrity Algorithm - AH:	%12
	Integrity Algorithm - ESP:	%13
	Encryption Algorithm:	%14

Security Association Information:
	Lifetime - seconds:	%15
	Lifetime - data:		%16
	Lifetime - packets:	%17
	Mode:			%18
	Role:			%19
	Quick Mode Filter ID:	%20
	Main Mode SA ID:	%21
	Quick Mode SA ID:	%22

Additional Information:
	Inbound SPI:		%23
	Outbound SPI:		%24
++++
  event:
    value: 5452
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec Quick Mode security association ended.
	
Local Endpoint:
	Network Address:	%1
	Port:			%2
	Tunnel Endpoint:		%3

Remote Endpoint:
	Network Address:	%4
	Port:			%5
	Tunnel Endpoint:		%6

Additional Information:
	Protocol:		%7
	Quick Mode SA ID:	%8
++++
  event:
    value: 5453
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An IPsec negotiation with a remote computer failed because the IKE and AuthIP IPsec Keying Modules (IKEEXT) service is not started.
++++
  event:
    value: 5456
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine applied Active Directory storage IPsec policy on the computer.

Policy:		%1
++++
  event:
    value: 5457
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine failed to apply Active Directory storage IPsec policy on the computer.

DN:		%1
Error code:		%2
++++
  event:
    value: 5458
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine applied locally cached copy of Active Directory storage IPsec policy on the computer.

Policy:		%1
++++
  event:
    value: 5459
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine failed to apply locally cached copy of Active Directory storage IPsec policy on the computer.

Policy:		%1
Error Code:		%2
++++
  event:
    value: 5460
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine applied local registry storage IPsec policy on the computer.

Policy:		%1
++++
  event:
    value: 5461
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine failed to apply local registry storage IPsec policy on the computer.

Policy:		%1
Error Code:		%2
++++
  event:
    value: 5462
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine failed to apply some rules of the active IPsec policy on the computer. Use the IP Security Monitor snap-in to diagnose the problem.

Policy:		%1
Error Code:		%2
++++
  event:
    value: 5463
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine polled for changes to the active IPsec policy and detected no changes.
++++
  event:
    value: 5464
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine polled for changes to the active IPsec policy, detected changes, and applied them to IPsec Services.
++++
  event:
    value: 5465
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine received a control for forced reloading of IPsec policy and processed the control successfully.
++++
  event:
    value: 5466
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine polled for changes to the Active Directory IPsec policy, determined that Active Directory cannot be reached, and will use the cached copy of the Active Directory IPsec policy instead. Any changes made to the Active Directory IPsec policy since the last poll could not be applied.
++++
  event:
    value: 5467
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine polled for changes to the Active Directory IPsec policy, determined that Active Directory can be reached, and found no changes to the policy. The cached copy of the Active Directory IPsec policy is no longer being used.
++++
  event:
    value: 5468
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine polled for changes to the Active Directory IPsec policy, determined that Active Directory can be reached, found changes to the policy, and applied those changes. The cached copy of the Active Directory IPsec policy is no longer being used.
++++
  event:
    value: 5471
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine loaded local storage IPsec policy on the computer.

Policy:		%1
++++
  event:
    value: 5472
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine failed to load local storage IPsec policy on the computer.

Policy:		%1
Error Code:		%2
++++
  event:
    value: 5473
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine loaded directory storage IPsec policy on the computer.

Policy:		%1
++++
  event:
    value: 5474
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine failed to load directory storage IPsec policy on the computer.

Policy:		%1
Error Code:		%2
++++
  event:
    value: 5477
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: PAStore Engine failed to add quick mode filter.

Quick Mode Filter:		%1
Error Code:		%2
++++
  event:
    value: 5478
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Services has started successfully.
++++
  event:
    value: 5479
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Services has been shut down successfully. The shutdown of IPsec Services can put the computer at greater risk of network attack or expose the computer to potential security risks.
++++
  event:
    value: 5480
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Services failed to get the complete list of network interfaces on the computer. This poses a potential security risk because some of the network interfaces may not get the protection provided by the applied IPsec filters. Use the IP Security Monitor snap-in to diagnose the problem.
++++
  event:
    value: 5483
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Services failed to initialize RPC server. IPsec Services could not be started.

Error Code:		%1
++++
  event:
    value: 5484
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Services has experienced a critical failure and has been shut down. The shutdown of IPsec Services can put the computer at greater risk of network attack or expose the computer to potential security risks.

Error Code:		%1
++++
  event:
    value: 5485
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: IPsec Services failed to process some IPsec filters on a plug-and-play event for network interfaces. This poses a potential security risk because some of the network interfaces may not get the protection provided by the applied IPsec filters. Use the IP Security Monitor snap-in to diagnose the problem.
++++
  event:
    value: 5632
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A request was made to authenticate to a wireless network.

Subject:
	Security ID:		%2
	Account Name:		%3
	Account Domain:		%4
	Logon ID:		%5

Network Information:
	Name (SSID):		%1
	Interface GUID:		%8
	Local MAC Address:	%7
	Peer MAC Address:	%6

Additional Information:
	Reason Code:		%10 (%9)
	Error Code:		%11
++++
  event:
    value: 5633
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A request was made to authenticate to a wired network.

Subject:
	Security ID:		%2
	Account Name:		%3
	Account Domain:		%4
	Logon ID:		%5

Interface:
	Name:			%1

Additional Information
	Reason Code:		%7 (%6)
	Error Code:		%8
++++
  event:
    value: 5712
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: A Remote Procedure Call (RPC) was attempted.

Subject:
	SID:			%1
	Name:			%2
	Account Domain:		%3
	LogonId:		%4

Process Information:
	PID:			%5
	Name:			%6

Network Information:
	Remote IP Address:	%7
	Remote Port:		%8

RPC Attributes:
	Interface UUID:		%9
	Protocol Sequence:	%10
	Authentication Service:	%11
	Authentication Level:	%12
++++
  event:
    value: 5888
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An object in the COM+ Catalog was modified.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	COM+ Catalog Collection:	%5
	Object Name:			%6
	Object Properties Modified:	%7
++++
  event:
    value: 5889
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An object was deleted from the COM+ Catalog.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	COM+ Catalog Collection:	%5
	Object Name:			%6
	Object Details:			%7
++This event occurs when an object is deleted from the COM+ catalog.++

  event:
    value: 5890
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: An object was added to the COM+ Catalog.

Subject:
	Security ID:		%1
	Account Name:		%2
	Account Domain:		%3
	Logon ID:		%4

Object:
	COM+ Catalog Collection:	%5
	Object Name:			%6
	Object Details:			%7

  event:
    value: 6144
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Security policy in the group policy objects has been applied successfully. 

Return Code:	%1

GPO List:
%2
++++
  event:
    value: 6145
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: One or more errors occured while processing security policy in the group policy objects.

Error Code:	%1
GPO List:
%2
++++
  event:
    value: 6272
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Network Policy Server granted access to a user.

User:
	Security ID:			%1
	Account Name:			%2
	Account Domain:			%3
	Fully Qualified Account Name:	%4

Client Machine:
	Security ID:			%5
	Account Name:			%6
	Fully Qualified Account Name:	%7
	OS-Version:			%8
	Called Station Identifier:		%9
	Calling Station Identifier:		%10

NAS:
	NAS IPv4 Address:		%11
	NAS IPv6 Address:		%12
	NAS Identifier:			%13
	NAS Port-Type:			%14
	NAS Port:			%15

RADIUS Client:
	Client Friendly Name:		%16
	Client IP Address:			%17

Authentication Details:
	Proxy Policy Name:		%18
	Network Policy Name:		%19
	Authentication Provider:		%20
	Authentication Server:		%21
	Authentication Type:		%22
	EAP Type:			%23
	Account Session Identifier:		%24

Quarantine Information:
	Result:				%25
	Session Identifier:			%26

++++
  event:
    value: 6273
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Network Policy Server denied access to a user.

++Contact the Network Policy Server administrator for more information.++

User:
	Security ID:			%1
	Account Name:			%2
	Account Domain:			%3
	Fully Qualified Account Name:	%4

Client Machine:
	Security ID:			%5
	Account Name:			%6
	Fully Qualified Account Name:	%7
	OS-Version:			%8
	Called Station Identifier:		%9
	Calling Station Identifier:		%10

NAS:
	NAS IPv4 Address:		%11
	NAS IPv6 Address:		%12
	NAS Identifier:			%13
	NAS Port-Type:			%14
	NAS Port:			%15

RADIUS Client:
	Client Friendly Name:		%16
	Client IP Address:			%17

Authentication Details:
	Proxy Policy Name:		%18
	Network Policy Name:		%19
	Authentication Provider:		%20
	Authentication Server:		%21
	Authentication Type:		%22
	EAP Type:			%23
	Account Session Identifier:		%24
	Reason Code:			%25
	Reason:				%26

  event:
    value: 6274
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Network Policy Server discarded the request for a user.

++Contact the Network Policy Server administrator for more information.++

User:
	Security ID:			%1
	Account Name:			%2
	Account Domain:			%3
	Fully Qualified Account Name:	%4

Client Machine:
	Security ID:			%5
	Account Name:			%6
	Fully Qualified Account Name:	%7
	OS-Version:			%8
	Called Station Identifier:		%9
	Calling Station Identifier:		%10

NAS:
	NAS IPv4 Address:		%11
	NAS IPv6 Address:		%12
	NAS Identifier:			%13
	NAS Port-Type:			%14
	NAS Port:			%15

RADIUS Client:
	Client Friendly Name:		%16
	Client IP Address:			%17

Authentication Details:
	Proxy Policy Name:		%18
	Network Policy Name:		%19
	Authentication Provider:		%20
	Authentication Server:		%21
	Authentication Type:		%22
	EAP Type:			%23
	Account Session Identifier:		%24
	Reason Code:			%25
	Reason:				%26

  event:
    value: 6275
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Network Policy Server discarded the accounting request for a user.

++Contact the Network Policy Server administrator for more information.++

User:
	Security ID:			%1
	Account Name:			%2
	Account Domain:			%3
	Fully Qualified Account Name:	%4

Client Machine:
	Security ID:			%5
	Account Name:			%6
	Fully Qualified Account Name:	%7
	OS-Version:			%8
	Called Station Identifier:		%9
	Calling Station Identifier:		%10

NAS:
	NAS IPv4 Address:		%11
	NAS IPv6 Address:		%12
	NAS Identifier:			%13
	NAS Port-Type:			%14
	NAS Port:			%15

RADIUS Client:
	Client Friendly Name:		%16
	Client IP Address:			%17

Authentication Details:
	Proxy Policy Name:		%18
	Network Policy Name:		%19
	Authentication Provider:		%20
	Authentication Server:		%21
	Authentication Type:		%22
	EAP Type:			%23
	Account Session Identifier:		%24
	Reason Code:			%25
	Reason:				%26

  event:
    value: 6276
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Network Policy Server quarantined a user.

++Contact the Network Policy Server administrator for more information.++

User:
	Security ID:			%1
	Account Name:			%2
	Account Domain:			%3
	Fully Qualified Account Name:	%4

Client Machine:
	Security ID:			%5
	Account Name:			%6
	Fully Qualified Account Name:	%7
	OS-Version:			%8
	Called Station Identifier:		%9
	Calling Station Identifier:		%10

NAS:
	NAS IPv4 Address:		%11
	NAS IPv6 Address:		%12
	NAS Identifier:			%13
	NAS Port-Type:			%14
	NAS Port:			%15

RADIUS Client:
	Client Friendly Name:		%16
	Client IP Address:			%17

Authentication Details:
	Proxy Policy Name:		%18
	Network Policy Name:		%19
	Authentication Provider:		%20
	Authentication Server:		%21
	Authentication Type:		%22
	EAP Type:			%23
	Account Session Identifier:		%24

Quarantine Information:
	Result:				%25
	Extended-Result:			%26
	Session Identifier:			%27
	Help URL:			%28
	System Health Validator Result(s):	%29

  event:
    value: 6277
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Network Policy Server granted access to a user but put it on probation because the host did not meet the defined health policy.

++Contact the Network Policy Server administrator for more information.++

User:
	Security ID:			%1
	Account Name:			%2
	Account Domain:			%3
	Fully Qualified Account Name:	%4

Client Machine:
	Security ID:			%5
	Account Name:			%6
	Fully Qualified Account Name:	%7
	OS-Version:			%8
	Called Station Identifier:		%9
	Calling Station Identifier:		%10

NAS:
	NAS IPv4 Address:		%11
	NAS IPv6 Address:		%12
	NAS Identifier:			%13
	NAS Port-Type:			%14
	NAS Port:			%15

RADIUS Client:
	Client Friendly Name:		%16
	Client IP Address:			%17

Authentication Details:
	Proxy Policy Name:		%18
	Network Policy Name:		%19
	Authentication Provider:		%20
	Authentication Server:		%21
	Authentication Type:		%22
	EAP Type:			%23
	Account Session Identifier:		%24

Quarantine Information:
	Result:				%25
	Extended-Result:			%26
	Session Identifier:			%27
	Help URL:			%28
	System Health Validator Result(s):	%29
	Quarantine Grace Time:		%30

  event:
    value: 6278
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Network Policy Server granted full access to a user because the host met the defined health policy.

User:
	Security ID:			%1
	Account Name:			%2
	Account Domain:			%3
	Fully Qualified Account Name:	%4

Client Machine:
	Security ID:			%5
	Account Name:			%6
	Fully Qualified Account Name:	%7
	OS-Version:			%8
	Called Station Identifier:		%9
	Calling Station Identifier:		%10

NAS:
	NAS IPv4 Address:		%11
	NAS IPv6 Address:		%12
	NAS Identifier:			%13
	NAS Port-Type:			%14
	NAS Port:			%15

RADIUS Client:
	Client Friendly Name:		%16
	Client IP Address:			%17

Authentication Details:
	Proxy Policy Name:		%18
	Network Policy Name:		%19
	Authentication Provider:		%20
	Authentication Server:		%21
	Authentication Type:		%22
	EAP Type:			%23
	Account Session Identifier:		%24

Quarantine Information:
	Result:				%25
	Extended-Result:			%26
	Session Identifier:			%27
	Help URL:			%28
	System Health Validator Result(s):	%29
++++
  event:
    value: 6279
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Network Policy Server locked the user account due to repeated failed authentication attempts.

User:
	Security ID:			%1
	Account Name:			%2
	Account Domain:			%3
	Fully Qualified Account Name:	%4
++++
  event:
    value: 6280
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Network Policy Server unlocked the user account.

User:
	Security ID:			%1
	Account Name:			%2
	Account Domain:			%3
	Fully Qualified Account Name:	%4
++++
  event:
    value: 8191
    version: 0
    opcode: 0
    channel: 10
    level: 4
    task: 0
    keywords: 0x8000000000000000
    message: Highest System-Defined Audit Message Value.
++++
endoffile
";
        #endregion
    }
    public class Reloading_EventsID
    {
        public static DataTable table_ = new DataTable("__BEV_MasterTable");
        public static DataColumn column_;
        public static DataRow row_;
        public static void Settable()
        {
            try
            {
                table_.Columns.Clear();
                table_.Rows.Clear();

                column_ = new DataColumn();
                column_.DataType = Type.GetType("System.String");
                column_.ColumnName = "EventID";
                table_.Columns.Add(column_);

                column_ = new DataColumn();
                column_.DataType = Type.GetType("System.String");
                column_.ColumnName = "Level";
                table_.Columns.Add(column_);

                column_ = new DataColumn();
                column_.DataType = Type.GetType("System.String");
                column_.ColumnName = "Event ID Description";
                table_.Columns.Add(column_);

                column_ = new DataColumn();
                column_.DataType = Type.GetType("System.String");
                column_.ColumnName = "More Information";
                table_.Columns.Add(column_);

            }
            catch (Exception err)
            {

                System.Diagnostics.Debug.WriteLine(err.Message);
            }


        }
        static string temp1, temp2, temp3, temp4 = " ";
        public static void SetRows_TO_tabl(string _EVENTID, string Level, string Messages, string _tooltips)
        {
            try
            {
                //if (_EVENTID != "0" && Level != "0" && Messages != "0")
                //{
                row_ = table_.NewRow();
                row_["EventID"] = _EVENTID;
                row_["Level"] = Level;
                row_["Event ID Description"] = Messages;
                row_["More Information"] = _tooltips;

                table_.Rows.Add(row_);
                // }
            }
            catch (Exception err)
            {

                System.Diagnostics.Debug.WriteLine(err.Message);
            }

        }
        public static void GetAllEvents(string filename)
        {
            //StreamReader s = new StreamReader(" ");
            try
            {
                Settable();
                int counter = 0;
                string line;
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.



                using (StreamReader sr = new StreamReader(filename, Encoding.ASCII))
                {


                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != "endoffile")
                    {

                        //Console.WriteLine(line);

                        if (line.Trim().StartsWith("value: "))
                        {
                            temp1 = line.Substring(11);
                            counter++;
                        }
                        if (line.Trim().StartsWith("level: "))
                        {
                            temp2 = line.Substring(11);
                            counter++;
                        }
                        if (line.Trim().StartsWith("message: "))
                        {
                            temp3 = line.Substring(13);
                            counter++;

                        }
                        if (counter == 3)
                        {
                            SetRows_TO_tabl(temp1, temp2, temp3, "");
                            counter = 0;
                            temp1 = "";
                            temp2 = "";
                            temp3 = "";
                        }


                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }
        public static void GetAllEvents(string filename, bool b)
        {
            //StreamReader s = new StreamReader(" ");
            try
            {
                Settable();
                int counter = 0;
                string line;
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                bool f = false;

                f = false;
                using (StreamReader sr = new StreamReader(filename, Encoding.ASCII))
                {


                    // Read and display lines from the file until the end of 
                    // the file is reached.

                    while ((line = sr.ReadLine()) != "endoffile")
                    {

                        //Console.WriteLine(line);

                        if (line.Trim().StartsWith("value: "))
                        {
                            f = false;
                            temp1 = line.Substring(11);
                            counter++;
                        }
                        if (line.Trim().StartsWith("level: "))
                        {
                            f = false;
                            temp2 = line.Substring(11);
                            counter++;
                        }
                        if (line.Trim().StartsWith("message: "))
                        {
                            f = true;
                            temp3 = line.Substring(13);
                            counter++;

                        }

                        if (f == true)
                        {
                            if (line.Trim().StartsWith("++") && line.Trim().EndsWith("++"))
                            {
                                //temp4 = temp4 + line + "\n";
                                temp4 = temp4 + line;
                                counter++;

                            }
                            else if (line.Trim().StartsWith("++") && (!line.Trim().EndsWith("++")))
                            {
                                //while ((!line.EndsWith("++")))
                                //{
                                //    //temp4 = temp4 + "\n" + sr.ReadLine();
                                //    temp4 = temp4 + "\n" + line;
                                //    if (temp4.EndsWith("++")) { counter++; break; }

                                temp4 = temp4 + line;
                                //}

                                while ((line = sr.ReadLine()) != "++")
                                {
                                    temp4 = temp4 + "\n" + line;
                                    if (temp4.EndsWith("++")) { counter++; break; }
                                }
                            }
                        }


                        if (counter == 4)
                        {
                            SetRows_TO_tabl(temp1, temp2, temp3, temp4);
                            counter = 0;
                            temp1 = "";
                            temp2 = "";
                            temp3 = "";
                            temp4 = "";
                            f = false;
                        }


                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

    }
    class MasterValueClass
    {
        public static string[] PropertiesList;
        public static string Local_Description_Groupbox6, Remote_Description_Groupbox6 = "Event Messages";
        public static TreeNode _RemoteConnection_Root_Nodes;
        public static TreeNode _LocalConnection_Root_Nodes;
        public static string Remote_Host_Name;
        public static string Remote_Host_UserName;
        public static string ActiveNode;
        public static string ActiveNode_Count;
        public static string ActiveNode_For_Remote;
        public static string ActiveNode_Count_For_Remote;
        public static BindingSource RemoteBindingSource = new BindingSource();
        public static BindingSource LocalBindingSource = new BindingSource();
        public static BindingSource LocalBindingSource_for_serach1 = new BindingSource();
        public static string Filtering_Types_local_Filter_Query;
        public static string Filtering_Types_Remote_Filter_Query;


        public static DataTable table_MitreAttackTechniques = new DataTable("BEV_MasterTable_Table_MitreAttackTechniques");
        public static DataColumn column_MitreAttackTechniques;
        public static DataRow row_MitreAttackTechniques;

        public static void Settable_MitreAttackTechniques()
        {
            try
            {
                table_MitreAttackTechniques.Columns.Clear();
                table_MitreAttackTechniques.Rows.Clear();

                column_MitreAttackTechniques = new DataColumn();
                column_MitreAttackTechniques.DataType = Type.GetType("System.Int32");
                column_MitreAttackTechniques.ColumnName = "Record_SubItemIndex";
                table_MitreAttackTechniques.Columns.Add(column_MitreAttackTechniques);
                 
                column_MitreAttackTechniques = new DataColumn();
                column_MitreAttackTechniques.DataType = Type.GetType("System.String");
                column_MitreAttackTechniques.ColumnName = "TechniqueDisplayName";
                table_MitreAttackTechniques.Columns.Add(column_MitreAttackTechniques);

                column_MitreAttackTechniques = new DataColumn();
                column_MitreAttackTechniques.DataType = Type.GetType("System.String");
                column_MitreAttackTechniques.ColumnName = "TechniqueID";
                table_MitreAttackTechniques.Columns.Add(column_MitreAttackTechniques);

                column_MitreAttackTechniques = new DataColumn();
                column_MitreAttackTechniques.DataType = Type.GetType("System.Int32");
                column_MitreAttackTechniques.ColumnName = "Technique_Steps_Index";
                table_MitreAttackTechniques.Columns.Add(column_MitreAttackTechniques);

                column_MitreAttackTechniques = new DataColumn();
                column_MitreAttackTechniques.DataType = Type.GetType("System.String");
                column_MitreAttackTechniques.ColumnName = "Technique_Step_Command";
                table_MitreAttackTechniques.Columns.Add(column_MitreAttackTechniques);

                column_MitreAttackTechniques = new DataColumn();
                column_MitreAttackTechniques.DataType = Type.GetType("System.String");
                column_MitreAttackTechniques.ColumnName = "Technique_Description";
                table_MitreAttackTechniques.Columns.Add(column_MitreAttackTechniques);

                column_MitreAttackTechniques = new DataColumn();
                column_MitreAttackTechniques.DataType = Type.GetType("System.String");
                column_MitreAttackTechniques.ColumnName = "yaml_File";
                table_MitreAttackTechniques.Columns.Add(column_MitreAttackTechniques);
            }
            catch (Exception err)
            {

                // System.Diagnostics.Debug.WriteLine(err.Message);
            }


        }
        public static void SetRows_TO_table_MitreAttackTechniques(DataTable SearchTable, Int32 Record_SubItemIndex, string TechniqueDisplayName,
            string TechniqueID, Int32 Technique_Steps_Index,string Technique_Step_Command, string Technique_Description, string yamlfile)
        {
            try
            {
                row_MitreAttackTechniques = SearchTable.NewRow();
                row_MitreAttackTechniques["Record_SubItemIndex"] = Record_SubItemIndex;
                row_MitreAttackTechniques["TechniqueDisplayName"] = TechniqueDisplayName;
                row_MitreAttackTechniques["TechniqueID"] = TechniqueID;
                row_MitreAttackTechniques["Technique_Steps_Index"] = Technique_Steps_Index;
                row_MitreAttackTechniques["Technique_Step_Command"] = Technique_Step_Command;
                row_MitreAttackTechniques["Technique_Description"] = Technique_Description;
                row_MitreAttackTechniques["yaml_File"] = yamlfile;

                SearchTable.Rows.Add(row_MitreAttackTechniques);
            }
            catch (Exception err)
            {

                System.Diagnostics.Debug.WriteLine(err.Message);
            }

        }

        public static DataTable table_Remoting = new DataTable("BEV_MasterTable_Remoting");
        public static DataColumn column_Remoting;
        public static DataRow row_Remoting;

        public static void Settable_RemoteTable()
        {
            try
            {
                table_Remoting.Columns.Clear();
                table_Remoting.Rows.Clear();

                column_Remoting = new DataColumn();
                column_Remoting.DataType = Type.GetType("System.String");
                column_Remoting.ColumnName = "Record";
                table_Remoting.Columns.Add(column_Remoting);

                column_Remoting = new DataColumn();
                column_Remoting.DataType = Type.GetType("System.String");
                column_Remoting.ColumnName = "Type";
                table_Remoting.Columns.Add(column_Remoting);

                column_Remoting = new DataColumn();
                column_Remoting.DataType = Type.GetType("System.String");
                column_Remoting.ColumnName = "EventID";
                table_Remoting.Columns.Add(column_Remoting);

                column_Remoting = new DataColumn();
                column_Remoting.DataType = Type.GetType("System.String");
                column_Remoting.ColumnName = "Message";
                table_Remoting.Columns.Add(column_Remoting);

                column_Remoting = new DataColumn();
                column_Remoting.DataType = Type.GetType("System.String");
                column_Remoting.ColumnName = "EventTime";
                table_Remoting.Columns.Add(column_Remoting);
            }
            catch (Exception err)
            {

                System.Diagnostics.Debug.WriteLine(err.Message);
            }


        }

        public static void SetRows_TO_table_Remoting(string RecordID, string Type, string Id, string Messages, string evt_time)
        {
            try
            {
                row_Remoting = table_Remoting.NewRow();
                row_Remoting["Record"] = RecordID;
                row_Remoting["Type"] = Type;
                row_Remoting["EventID"] = Id;
                row_Remoting["Message"] = Messages;
                row_Remoting["EventTime"] = evt_time;

                table_Remoting.Rows.Add(row_Remoting);
            }
            catch (Exception err)
            {

                System.Diagnostics.Debug.WriteLine(err.Message);
            }

        }


        public static DataTable table_Local = new DataTable("BEV_MasterTable_Local");
        public static DataColumn column_Local;
        public static DataRow row_Local;

        public static DataTable table_Local_search1 = new DataTable("BEV_MasterTable_Local_for_search1");
        public static DataColumn column_Local_search1;
        public static DataRow row_Local_search1;

        public static DataTable table_Local_search1_Results = new DataTable("BEV_MasterTable_Local_for_search1_result");
        public static DataColumn column_Local_search1_Results;
        public static DataRow row_Local_search1_Results;

        public static DataTable table_Local_searchAll_Results = new DataTable("BEV_MasterTable_Local_for_searchAll_result");
        public static DataColumn column_Local_searchAll_Results;
        public static DataRow row_Local_searchAll_Results;

        public static void Settable_LocalTable()
        {
            try
            {
                table_Local.Columns.Clear();
                table_Local.Rows.Clear();

                column_Local = new DataColumn();
                column_Local.DataType = Type.GetType("System.String");
                column_Local.ColumnName = "Record";
                table_Local.Columns.Add(column_Local);


                column_Local = new DataColumn();
                column_Local.DataType = Type.GetType("System.String");
                column_Local.ColumnName = "Type";
                table_Local.Columns.Add(column_Local);

                column_Local = new DataColumn();
                column_Local.DataType = Type.GetType("System.String");
                column_Local.ColumnName = "EventID";
                table_Local.Columns.Add(column_Local);


                column_Local = new DataColumn();
                column_Local.DataType = Type.GetType("System.String");
                column_Local.ColumnName = "Message";
                table_Local.Columns.Add(column_Local);

                column_Local = new DataColumn();
                column_Local.DataType = Type.GetType("System.String");
                column_Local.ColumnName = "EventTime";
                table_Local.Columns.Add(column_Local);
            }
            catch (Exception err)
            {

                System.Diagnostics.Debug.WriteLine(err.Message);
            }


        }

        public static void Settable_LocalTable_for_search1()
        {
            try
            {
                table_Local_search1.Columns.Clear();
                table_Local_search1.Rows.Clear();

                column_Local_search1 = new DataColumn();
                column_Local_search1.DataType = Type.GetType("System.String");
                column_Local_search1.ColumnName = "Record";
                table_Local_search1.Columns.Add(column_Local_search1);


                column_Local_search1 = new DataColumn();
                column_Local_search1.DataType = Type.GetType("System.String");
                column_Local_search1.ColumnName = "Type";
                table_Local_search1.Columns.Add(column_Local_search1);

                column_Local_search1 = new DataColumn();
                column_Local_search1.DataType = Type.GetType("System.String");
                column_Local_search1.ColumnName = "EventID";
                table_Local_search1.Columns.Add(column_Local_search1);


                column_Local_search1 = new DataColumn();
                column_Local_search1.DataType = Type.GetType("System.String");
                column_Local_search1.ColumnName = "Message";
                table_Local_search1.Columns.Add(column_Local_search1);

                column_Local_search1 = new DataColumn();
                column_Local_search1.DataType = Type.GetType("System.String");
                column_Local_search1.ColumnName = "EventTime";
                table_Local_search1.Columns.Add(column_Local_search1);

                column_Local_search1 = new DataColumn();
                column_Local_search1.DataType = Type.GetType("System.Object");
                column_Local_search1.ColumnName = "EventRecord_Objects";
                table_Local_search1.Columns.Add(column_Local_search1);
            }
            catch (Exception err)
            {

               // System.Diagnostics.Debug.WriteLine(err.Message);
            }


        }

        public static void Settable_LocalTable_for_search1_result()
        {
            try
            {
                table_Local_search1_Results.Columns.Clear();
                table_Local_search1_Results.Rows.Clear();

                column_Local_search1_Results = new DataColumn();
                column_Local_search1_Results.DataType = Type.GetType("System.String");
                column_Local_search1_Results.ColumnName = "Record";
                table_Local_search1_Results.Columns.Add(column_Local_search1_Results);


                column_Local_search1_Results = new DataColumn();
                column_Local_search1_Results.DataType = Type.GetType("System.String");
                column_Local_search1_Results.ColumnName = "Type";
                table_Local_search1_Results.Columns.Add(column_Local_search1_Results);

                column_Local_search1_Results = new DataColumn();
                column_Local_search1_Results.DataType = Type.GetType("System.String");
                column_Local_search1_Results.ColumnName = "EventID";
                table_Local_search1_Results.Columns.Add(column_Local_search1_Results);

                column_Local_search1_Results = new DataColumn();
                column_Local_search1_Results.DataType = Type.GetType("System.String");
                column_Local_search1_Results.ColumnName = "Message";
                table_Local_search1_Results.Columns.Add(column_Local_search1_Results);
                
                column_Local_search1_Results = new DataColumn();
                column_Local_search1_Results.DataType = Type.GetType("System.String");
                column_Local_search1_Results.ColumnName = "EventTime";
                table_Local_search1_Results.Columns.Add(column_Local_search1_Results);
                
                column_Local_search1_Results = new DataColumn();
                column_Local_search1_Results.DataType = Type.GetType("System.Object");
                column_Local_search1_Results.ColumnName = "EventRecord_Objects";
                table_Local_search1_Results.Columns.Add(column_Local_search1_Results);
            }
            catch (Exception err)
            {

                // System.Diagnostics.Debug.WriteLine(err.Message);
            }


        }

        public static void Settable_LocalTable_for_searchAll_result()
        {
            try
            {
                table_Local_searchAll_Results.Columns.Clear();
                table_Local_searchAll_Results.Rows.Clear();

                column_Local_searchAll_Results = new DataColumn();
                column_Local_searchAll_Results.DataType = Type.GetType("System.String");
                column_Local_searchAll_Results.ColumnName = "Record";
                table_Local_searchAll_Results.Columns.Add(column_Local_searchAll_Results);

                column_Local_searchAll_Results = new DataColumn();
                column_Local_searchAll_Results.DataType = Type.GetType("System.String");
                column_Local_searchAll_Results.ColumnName = "Type";
                table_Local_searchAll_Results.Columns.Add(column_Local_searchAll_Results);

                column_Local_searchAll_Results = new DataColumn();
                column_Local_searchAll_Results.DataType = Type.GetType("System.String");
                column_Local_searchAll_Results.ColumnName = "EventID";
                table_Local_searchAll_Results.Columns.Add(column_Local_searchAll_Results);

                column_Local_searchAll_Results = new DataColumn();
                column_Local_searchAll_Results.DataType = Type.GetType("System.String");
                column_Local_searchAll_Results.ColumnName = "Message";
                table_Local_searchAll_Results.Columns.Add(column_Local_searchAll_Results);

                column_Local_searchAll_Results = new DataColumn();
                column_Local_searchAll_Results.DataType = Type.GetType("System.String");
                column_Local_searchAll_Results.ColumnName = "EventTime";
                table_Local_searchAll_Results.Columns.Add(column_Local_searchAll_Results);

                column_Local_searchAll_Results = new DataColumn();
                column_Local_searchAll_Results.DataType = Type.GetType("System.String");
                column_Local_searchAll_Results.ColumnName = "TechniqueNames";
                table_Local_searchAll_Results.Columns.Add(column_Local_searchAll_Results);

                column_Local_searchAll_Results = new DataColumn();
                column_Local_searchAll_Results.DataType = Type.GetType("System.String");
                column_Local_searchAll_Results.ColumnName = "TechniqueIDs";
                table_Local_searchAll_Results.Columns.Add(column_Local_searchAll_Results);

                column_Local_searchAll_Results = new DataColumn();
                column_Local_searchAll_Results.DataType = Type.GetType("System.String");
                column_Local_searchAll_Results.ColumnName = "Query";
                table_Local_searchAll_Results.Columns.Add(column_Local_searchAll_Results);

                column_Local_searchAll_Results = new DataColumn();
                column_Local_searchAll_Results.DataType = Type.GetType("System.Object");
                column_Local_searchAll_Results.ColumnName = "EventRecord_Objects";
                table_Local_searchAll_Results.Columns.Add(column_Local_searchAll_Results);

            }
            catch (Exception err)
            {

                // System.Diagnostics.Debug.WriteLine(err.Message);
            }


        }

        public static void SetRows_TO_table_Local(string RecordID, string Type, string Id, string Messages, string evt_time)
        {
            try
            {
                row_Local = table_Local.NewRow();
                row_Local["Record"] = RecordID;
                row_Local["Type"] = Type;
                row_Local["EventID"] = Id;
                row_Local["Message"] = Messages;
                row_Local["EventTime"] = evt_time;

                table_Local.Rows.Add(row_Local);
            }
            catch (Exception err)
            {

                System.Diagnostics.Debug.WriteLine(err.Message);
            }

        }

        public static void SetRows_TO_table_Local_for_Search1(DataTable SearchTable,string RecordID, string Type, string Id, string Messages, string evt_time , Object obj)
        {
            try
            {
                row_Local_search1_Results = SearchTable.NewRow();
                row_Local_search1_Results["Record"] = RecordID;
                row_Local_search1_Results["Type"] = Type;
                row_Local_search1_Results["EventID"] = Id;
                row_Local_search1_Results["Message"] = Messages;
                row_Local_search1_Results["EventTime"] = evt_time;
                row_Local_search1_Results["EventRecord_Objects"] = obj;

                SearchTable.Rows.Add(row_Local_search1_Results);
            }
            catch (Exception err)
            {

                System.Diagnostics.Debug.WriteLine(err.Message);
            }

        }

        public static void SetRows_TO_table_Local_for_SearchAll(DataTable SearchTable, string RecordID, string Type, string Id, 
            string Messages, string evt_time , string TechniqueNames , string TechniqueIDs,string _AutoQuery,object obj)
        {
            try
            {
                row_Local_searchAll_Results = SearchTable.NewRow();
                row_Local_searchAll_Results["Record"] = RecordID;
                row_Local_searchAll_Results["Type"] = Type;
                row_Local_searchAll_Results["EventID"] = Id;
                row_Local_searchAll_Results["Message"] = Messages;
                row_Local_searchAll_Results["EventTime"] = evt_time;
                row_Local_searchAll_Results["TechniqueNames"] = TechniqueNames;
                row_Local_searchAll_Results["TechniqueIDs"] = TechniqueIDs;
                row_Local_searchAll_Results["Query"] = _AutoQuery;
                row_Local_searchAll_Results["EventRecord_Objects"] = obj;

                SearchTable.Rows.Add(row_Local_searchAll_Results);
            }
            catch (Exception err)
            {

                System.Diagnostics.Debug.WriteLine(err.Message);
            }

        }

    }
}
