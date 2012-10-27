using System;
using Monobjc.Foundation;

namespace Monobjc.Security
{
	/// <summary>
	/// Block called with the results of a call to SecKeyGeneratePairAsync.
	/// </summary>
	public delegate void SecKeyGeneratePairBlock(IntPtr publicKey, IntPtr privateKey, NSError error);

	/// <summary>
	/// Block called with the results of a call to SecTrustEvaluateAsync.
	/// </summary>
	public delegate void SecTrustCallback(IntPtr trustRef, SecTrustResultType trustResult);
}
