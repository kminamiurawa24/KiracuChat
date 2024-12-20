package com.example.kiracuchat.network.base

import okhttp3.Interceptor
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.logging.HttpLoggingInterceptor

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
}