using System;

namespace Monobjc.Foundation
{
    /// <summary>
    /// Represents the SSL protocol version.
    /// </summary>
    /// <remarks>>Forward declaration to avoid circular dependencies between Foundation and Security.</remarks>
    public enum SSLProtocol
    {
        /// <summary>
        /// Specifies that no protocol has been or should be negotiated or specified; use default.
        /// </summary>
        kSSLProtocolUnknown = 0,
        /// <summary>
        /// Specifies that the SSL 3.0 protocol is preferred; the SSL 2.0 protocol may be negotiated if the peer cannot use the SSL 3.0 protocol.
        /// </summary>
        kSSLProtocol3 = 2,
        /// <summary>
        /// Specifies that the TLS 1.0 protocol is preferred but lower versions may be negotiated.
        /// </summary>
        kTLSProtocol1 = 4,
        /// <summary>
        /// Specifies that the TLS 1.1 protocol is preferred but lower versions may be negotiated.
        /// </summary>
        kTLSProtocol11 = 7,
        /// <summary>
        /// Specifies that the TLS 1.2 protocol is preferred but lower versions may be negotiated.
        /// </summary>
        kTLSProtocol12 = 8,
        /// <summary>
        /// Specifies that the DTLS 1.0 protocol is preferred but lower versions may be negotiated.
        /// </summary>
        kDTLSProtocol1 = 9,
        /// <summary>
        /// Specifies that only the SSL 2.0 protocol may be negotiated. Deprecated in iOS.
        /// </summary>
        kSSLProtocol2 = 1,
        /// <summary>
        /// Specifies that only the SSL 3.0 protocol may be negotiated; fails if the peer tries to negotiate the SSL 2.0 protocol. Deprecated in iOS.
        /// </summary>
        kSSLProtocol3Only = 3,
        /// <summary>
        /// Specifies that only the TLS 1.0 protocol may be negotiated. Deprecated in iOS.
        /// </summary>
        kTLSProtocol1Only = 5,
        /// <summary>
        /// Specifies all supported versions. Deprecated in iOS.
        /// </summary>
        kSSLProtocolAll = 6,
    }
}
