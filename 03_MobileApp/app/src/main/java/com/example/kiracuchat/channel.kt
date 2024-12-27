package com.example.kiracuchat

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.ImageButton
import android.widget.ImageView
import androidx.activity.ComponentActivity

class channel : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    setContentView(R.layout.channel)
        val userOptionBtn: ImageView = findViewById(R.id.user_icon_option)

        userOptionBtn.setOnClickListener {
            startActivity(Intent(this, UserOptionActivity::class.java))
        }
    }
}