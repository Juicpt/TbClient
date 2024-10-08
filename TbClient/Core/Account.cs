using System.Security.Cryptography;

namespace TbClient.Core;

public class Account(string bduss = "", string stoken = "")
{
    public string Bduss { get; private set; } = bduss;
    public string Stoken { get; private set; } = stoken;

    private string? _androidId;
    private string? _uuid;
    private string? _cuid;
    private string? _cuidGalaxy2;
    private string? _c3Aid;
    private byte[]? _aesEcbSecKey;
    private Aes? _aesEcbCipher;
    private byte[]? _aesCbcSecKey;
    private Aes? _aesCbcCipher;

    public string AndroidId
    {
        get => _androidId ??= BitConverter.ToString(RandomNumberGenerator.GetBytes(8)).Replace("-", "").ToLower();
        set => _androidId = value;
    }

    public string Uuid
    {
        get => _uuid ??= Guid.NewGuid().ToString();
        set => _uuid = value;
    }

    public string? Tbs { get; set; }

    public string? ClientId { get; set; }

    public string? SampleId { get; set; }

    public string? Cuid => _cuid ??= "baidutiebaapp" + Uuid;

    public string CuidGalaxy2 => _cuidGalaxy2 ??= TbCrypto.CuidGalaxy2(AndroidId);

    public string? C3Aid => _c3Aid ??= TbCrypto.C3Aid(AndroidId, Uuid);

    public string? ZId { get; set; }

    public byte[] AesEcbSecKey => _aesEcbSecKey ??= RandomNumberGenerator.GetBytes(31);

    public Aes? AesEcbCipher
    {
        get
        {
            if (_aesEcbCipher != null) return _aesEcbCipher;
            var aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.Key = new Rfc2898DeriveBytes(AesEcbSecKey, [0xa4, 0x0b, 0xc8, 0x34, 0xd6, 0x95, 0xf3, 0x13], 5,
                HashAlgorithmName.SHA1).GetBytes(32);

            _aesEcbCipher = aes;

            return _aesEcbCipher;
        }
    }

    public byte[] AesCbcSecKey
    {
        get => _aesCbcSecKey ??= RandomNumberGenerator.GetBytes(16);
        set => _aesCbcSecKey = value;
    }

    public Aes? AesCbcCipher
    {
        get
        {
            if (_aesCbcCipher != null) return _aesCbcCipher;
            var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding  = PaddingMode.None;
            aes.Key = AesCbcSecKey;
            aes.IV = new byte[16];
            _aesCbcCipher = aes;
            return _aesCbcCipher;
        }
    }
}