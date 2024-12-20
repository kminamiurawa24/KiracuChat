package com.example.kiracuchat.network.service

import com.example.kiracuchat.model.PongRes
import retrofit2.http.GET

interface ContestService {

    @GET("Contest/ping")
    suspend fun ping(): PongRes

}