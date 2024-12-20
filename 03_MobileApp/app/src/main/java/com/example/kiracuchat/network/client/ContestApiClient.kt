package com.example.kiracuchat.network.client

import com.example.kiracuchat.model.PingRes
import com.example.kiracuchat.network.service.ContestService
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class ContestApiClient {

    private val retrofit: Retrofit = Retrofit.Builder()
        .baseUrl("https://192.168.40.125:7287/") // ベースURLを設定
        .addConverterFactory(GsonConverterFactory.create()) // GsonConverterFactoryを追加
        .build()

    private val service: ContestService = retrofit.create(ContestService::class.java)

    suspend fun ping(): PingRes? {
        return withContext(Dispatchers.IO) {
            try {
                service.ping()
            } catch (e: Exception) {
                // エラー処理
                null
            }
        }
    }
}