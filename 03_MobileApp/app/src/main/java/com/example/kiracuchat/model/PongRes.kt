package com.example.kiracuchat.model

data class PongRes(
    @SerializedName("message") val message: String,
    @SerializedName("timestamp") val timestamp: String // もしくは LocalDateTime 型
)
