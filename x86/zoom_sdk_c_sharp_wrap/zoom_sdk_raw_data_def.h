#define _ZOOM_SDK_RAW_DATA_DEF_H_
class AudioRawData
{
public:
    virtual bool CanAddRef() = 0;

    virtual bool AddRef() = 0;

    virtual int Release() = 0;

    virtual char* GetBuffer() = 0;

    virtual unsigned int GetBufferLen() = 0;

    virtual unsigned int GetSampleRate() = 0;

    virtual unsigned int GetChannelNum() = 0;
    virtual ~AudioRawData() {}
};

class YUVRawDataI420
{
public:
    virtual bool CanAddRef() = 0;

    virtual bool AddRef() = 0;

    virtual int Release() = 0;

    virtual char* GetYBuffer() = 0;

    virtual char* GetUBuffer() = 0;

    virtual char* GetVBuffer() = 0;

    virtual char* GetBuffer() = 0;

    virtual unsigned int GetBufferLen() = 0;

    virtual bool IsLimitedI420() = 0;

    virtual unsigned int GetStreamWidth() = 0;

    virtual unsigned int GetStreamHeight() = 0;

    virtual unsigned int GetRotation() = 0;

    virtual unsigned int GetSourceID() = 0;
    virtual ~YUVRawDataI420() {}
};

class YUVProcessDataI420
{
public:
    virtual unsigned int GetWidth() = 0;
    virtual unsigned int GetHeight() = 0;

    virtual char* GetYBuffer(unsigned int lineNum = 0) = 0;
    virtual char* GetUBuffer(unsigned int lineNum = 0) = 0;
    virtual char* GetVBuffer(unsigned int lineNum = 0) = 0;

    virtual unsigned int GetYStride() = 0;
    virtual unsigned int GetUStride() = 0;
    virtual unsigned int GetVStride() = 0;

    virtual unsigned int GetRotation() = 0;
    virtual bool IsLimitedI420() = 0;
    virtual ~YUVProcessDataI420() {}
};

class IYUVRawDataI420Converter
{
public:
    virtual YUVRawDataI420* ConvertToYUV() = 0;

    virtual YUVRawDataI420* ConvertToYUVViaExternalBuffer(char* buffer_, int size_) = 0;

    virtual void FillToPixelBuffer(char* ybuffer_, int ybuffer_pre_row_bytes, char* uvbuffer_, int uvbuffer_pre_row_bytes, int width, int height) = 0;

    virtual ~IYUVRawDataI420Converter() {}
};

