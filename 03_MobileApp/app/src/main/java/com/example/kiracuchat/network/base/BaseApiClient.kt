package com.example.kiracuchat.network.base

import com.example.kiracuchat.MyApplication
import com.example.kiracuchat.R
import com.example.kiracuchat.network.service.ContestService
import okhttp3.Interceptor
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.logging.HttpLoggingInterceptor
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.io.InputStream
import java.security.KeyStore
import java.security.SecureRandom
import java.security.cert.CertificateFactory
import java.security.cert.X509Certificate
import javax.net.ssl.SSLContext
import javax.net.ssl.TrustManager
import javax.net.ssl.TrustManagerFactory
import javax.net.ssl.X509TrustManager

object  BaseApiClient {

    private val client = OkHttpClient.Builder()
        .addInterceptor { chain -> createHeaderInterceptor().intercept(chain) } // ラムダ式でラップする
        .addInterceptor(createLoggingInterceptor())
        .build()

    fun executeRequest(request: Request) = client.newCall(request).execute()

    private fun createHeaderInterceptor() = Interceptor { chain ->
        val originalRequest = chain.request()
        // 必要に応じてヘッダーを追加
        val requestWithHeaders = originalRequest.newBuilder()
            .header("Authorization", "Bearer <token>") // 例: 認証トークン
            .header("Content-Type", "application/json") // 例: Content-Type
            .build()
        chain.proceed(requestWithHeaders)
    }

    private fun createLoggingInterceptor(): HttpLoggingInterceptor {
        val loggingInterceptor = HttpLoggingInterceptor()
        loggingInterceptor.level = HttpLoggingInterceptor.Level.BODY // リクエストとレスポンスボディをログ出力
        return loggingInterceptor
    }

    fun createOkHttpClient(): OkHttpClient {
        val trustManager = getTrustManagerForCertificate(R.raw.ca) // 証明書を設定

        // sslContext をここで生成
        val sslContext = SSLContext.getInstance("TLS")
        sslContext.init(null, arrayOf<TrustManager>(trustManager), SecureRandom())

        return OkHttpClient.Builder()
            .sslSocketFactory(sslContext.socketFactory, trustManager) // SSLSocketFactoryを設定
            .build()
    }

    // 証明書からTrustManagerを取得する関数
    private fun getTrustManagerForCertificate(certResId: Int): X509TrustManager {
        val certificateFactory = CertificateFactory.getInstance("X.509")
        val inputStream: InputStream = MyApplication.context.resources.openRawResource(certResId)
        val certificate: X509Certificate = certificateFactory.generateCertificate(inputStream) as X509Certificate
        inputStream.close()

        val keyStore = KeyStore.getInstance(KeyStore.getDefaultType())
        keyStore.load(null, null)
        keyStore.setCertificateEntry("ca", certificate)

        val trustManagerFactory = TrustManagerFactory.getInstance(TrustManagerFactory.getDefaultAlgorithm())
        trustManagerFactory.init(keyStore)

        return trustManagerFactory.trustManagers.first { it is X509TrustManager } as X509TrustManager
    }
}