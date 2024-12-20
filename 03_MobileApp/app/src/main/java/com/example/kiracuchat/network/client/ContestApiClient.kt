package com.example.kiracuchat.network.client

import android.util.Log
import com.example.kiracuchat.model.PingRes
import com.example.kiracuchat.network.base.ApiProvider
import com.example.kiracuchat.network.base.BaseApiClient
import com.example.kiracuchat.network.service.ContestService
import com.google.gson.Gson
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import okhttp3.Request
import retrofit2.Response
import java.io.IOException

class ContestApiClient {

    private val service: ContestService = ApiProvider.createService(ContestService::class.java)

    suspend fun ping(): PingRes? {
        return withContext(Dispatchers.IO) {
            try {
                val response: Response<PingRes> = service.ping() // ContestServiceのping()関数を呼び出す
                if (response.isSuccessful) {
                    response.body() // レスポンスボディを取得
                } else {
                    Log.e("ContestApiClient", "ping() failed: ${response.code()} ${response.message()}")
                    null
                }
            } catch (e: Exception) {
                Log.e("ContestApiClient", "ping() failed: ${e.message}", e)
                null
            }
        }
    }
}