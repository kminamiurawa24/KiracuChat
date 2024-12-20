package com.example.kiracuchat.network.service

import com.example.kiracuchat.model.PingRes
import retrofit2.Response
import retrofit2.http.GET

interface ContestService {
    @GET("Contest/ping")
    suspend fun ping(): Response<PingRes>
}