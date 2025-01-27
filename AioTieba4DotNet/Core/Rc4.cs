namespace AioTieba4DotNet.Core;

public class Rc4
{
    private readonly byte[] _s = new byte[256];
    private int _x;
    private int _y;
    private const byte XorConst = 42; // 定义常量 42

    public Rc4(byte[] key)
    {
        KeySetup(key);
    }

    // 初始化密钥
    private void KeySetup(byte[] key)
    {
        var keyLength = key.Length;
        for (var i = 0; i < 256; i++)
        {
            _s[i] = (byte)i;
        }

        var j = 0;
        for (var i = 0; i < 256; i++)
        {
            j = (j + _s[i] + key[i % keyLength]) & 255;
            Swap(i, j);
        }
    }

    // 生成伪随机字节流并进行加解密
    public byte[] Crypt(byte[] data)
    {
        var output = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
        {
            _x = (_x + 1) & 255;
            _y = (_y + _s[_x]) & 255;
            Swap(_x, _y);

            var xorIndex = (byte)((_s[_x] + _s[_y]) & 255);
            // 先进行RC4加密/解密，然后额外进行一次42异或
            output[i] = (byte)((data[i] ^ _s[xorIndex]) ^ XorConst);
        }

        return output;
    }

    // 交换数组中的两个元素
    private void Swap(int i, int j)
    {
        (_s[i], _s[j]) = (_s[j], _s[i]);
    }
}
